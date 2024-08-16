"""
Unit test class for the Generator module.
"""

import os
import platform
import shutil
from pathlib import Path

import pytest
from syrupy.assertion import SnapshotAssertion
from typer.testing import CliRunner

from bo4egenerator import generator
from bo4egenerator.cli import app as cli_app
from bo4egenerator.duplicates import remove_duplicate_definitions


@pytest.fixture(scope="module")
def test_data_root():
    return Path(__file__).parent / "test-data"


@pytest.fixture(scope="module")
def schemas_dir(test_data_root):
    return test_data_root / "schemas"


@pytest.fixture(scope="function")
def output_dir(test_data_root):
    output_dir = test_data_root / "generated-dotnet-classes"
    output_dir.mkdir(parents=True, exist_ok=True)
    yield output_dir
    shutil.rmtree(output_dir)


@pytest.fixture(scope="module")
def quicktype_executable():
    path_app_data = os.getenv("APPDATA")
    if platform.system() == "Windows" and path_app_data:
        return os.path.join(path_app_data, "npm", "quicktype.cmd")
    return "quicktype"  # Assuming it's in PATH on Linux (GH Actions)


class TestGenerator:
    """
    Unit test class for the Generator module.
    """

    def test_generate_csharp_classes(self, test_data_root, schemas_dir, output_dir, quicktype_executable):
        """
        Test case for generating C# classes using the `generate_csharp_classes` method.
        """
        generator.generate_csharp_classes(test_data_root, schemas_dir, output_dir, quicktype_executable)
        angebot_file = output_dir / "bo" / "Angebot.cs"
        assert angebot_file.exists(), f"Expected file {angebot_file} was not generated"

    def test_generate_csharp_classes_snapshot(
        self, test_data_root, schemas_dir, output_dir, quicktype_executable, snapshot: SnapshotAssertion
    ):
        """
        Test case for generating C# classes and comparing with snapshots.
        """
        generator.generate_csharp_classes(test_data_root, schemas_dir, output_dir, quicktype_executable)

        generated_files = sorted(output_dir.glob("**/*.cs"))
        for file in generated_files:
            relative_path = file.relative_to(output_dir)
            with file.open("r", encoding="utf-8") as f:
                content = f.read()
            assert content == snapshot(name=str(relative_path))

    def test_remove_duplicate_definitions(
        self, test_data_root, schemas_dir, output_dir, quicktype_executable, snapshot: SnapshotAssertion
    ):
        """
        Test case for removing duplicate definitions from generated C# classes.
        """
        generator.generate_csharp_classes(test_data_root, schemas_dir, output_dir, quicktype_executable)
        remove_duplicate_definitions(output_dir)

        generated_files = sorted(output_dir.glob("**/*.cs"))
        for file in generated_files:
            relative_path = file.relative_to(output_dir)
            with file.open("r", encoding="utf-8") as f:
                content = f.read()
            assert content == snapshot(name=f"no_duplicates_{relative_path}")

    def test_cli_main(self, schemas_dir, output_dir, snapshot: SnapshotAssertion):
        """
        Test case for the CLI main function.
        """
        runner = CliRunner()

        result = runner.invoke(cli_app, [str(schemas_dir), "--output", str(output_dir)])
        assert result.exit_code == 0, f"CLI command failed with error: {result.output}"

        generated_files = sorted(output_dir.glob("**/*.cs"))
        for file in generated_files:
            relative_path = file.relative_to(output_dir)
            with file.open("r", encoding="utf-8") as f:
                content = f.read()
            assert content == snapshot(name=f"cli_{relative_path}")

    def test_error_handling_invalid_schemas_dir(self, test_data_root, output_dir, quicktype_executable):
        """
        Test case for error handling when given an invalid schemas directory.
        """
        invalid_schemas_dir = test_data_root / "non_existent_dir"

        with pytest.raises(ValueError, match="Schemas directory does not exist"):
            generator.generate_csharp_classes(test_data_root, invalid_schemas_dir, output_dir, quicktype_executable)

    def test_duplicate_removal_specific_cases(
        self, test_data_root, schemas_dir, output_dir, quicktype_executable, snapshot: SnapshotAssertion
    ):
        """
        Test case for specific duplicate removal scenarios.
        """
        generator.generate_csharp_classes(test_data_root, schemas_dir, output_dir, quicktype_executable)

        # Add some duplicate definitions manually for testing
        test_file = output_dir / "bo" / "TestDuplicates.cs"
        with test_file.open("w", encoding="utf-8") as f:
            f.write(
                """
namespace BO4EDotNet
{
    public partial class TestClass
    {
        // Original content
    }

    public partial class TestClass
    {
        // Duplicate content
    }

    public enum TestEnum
    {
        Value1,
        Value2
    }

    public enum TestEnum
    {
        Value1,
        Value2,
        Value3
    }
}
"""
            )

        remove_duplicate_definitions(output_dir)

        with test_file.open("r", encoding="utf-8") as f:
            content = f.read()
        assert content == snapshot(name="specific_duplicate_removal")

    def test_generated_class_structure(self, test_data_root, schemas_dir, output_dir, quicktype_executable):
        """
        Test case to verify the structure of generated C# classes.
        """
        generator.generate_csharp_classes(test_data_root, schemas_dir, output_dir, quicktype_executable)

        angebot_file = output_dir / "bo" / "Angebot.cs"
        assert angebot_file.exists(), f"Expected file {angebot_file} was not generated"

        with angebot_file.open("r", encoding="utf-8") as f:
            content = f.read()

        assert "namespace BO4EDotNet" in content, "Namespace BO4EDotNet not found in generated class"
        assert "public partial class Angebot" in content, "Angebot class not found in generated file"
        assert "using System;" in content, "Using System directive not found in generated file"
        assert "using Newtonsoft.Json;" in content, "Using Newtonsoft.Json directive not found in generated file"

    def test_cli_help(self):
        """
        Test case for CLI help message.
        """
        runner = CliRunner()
        result = runner.invoke(cli_app, ["--help"])
        assert result.exit_code == 0
        assert "Generate C# classes from the BO4E schema files" in result.output
