"""
Unit test class for the Generator module.
"""

import os
import platform
from pathlib import Path
from typing import Generator

import pytest
from syrupy.assertion import SnapshotAssertion  # pylint: disable=import-error
from typer.testing import CliRunner

from bo4egenerator import generator
from bo4egenerator.cli import app as cli_app


@pytest.fixture(scope="module")
def test_data_root() -> Path:
    return Path(__file__).parent / "test-data"


@pytest.fixture(scope="module")
def schemas_dir(test_data_root: Path) -> Path:
    return test_data_root / "schemas"


@pytest.fixture(scope="function")
def output_dir(test_data_root: Path) -> Generator[Path, None, None]:
    output_dir = test_data_root / "generated-classes"
    output_dir.mkdir(parents=True, exist_ok=True)
    yield output_dir


@pytest.fixture(scope="module")
def quicktype_executable() -> str:
    path_app_data = os.getenv("APPDATA")
    if platform.system() == "Windows" and path_app_data:
        return os.path.join(path_app_data, "npm", "quicktype.cmd")
    return "quicktype"  # Assuming it's in PATH on Linux (GH Actions)


class TestGenerator:
    """
    Unit test class for the Generator module.
    """

    def test_generate_csharp_classes(
        self, test_data_root: Path, schemas_dir: Path, output_dir: Path, quicktype_executable: str
    ) -> None:
        """
        Test case for generating C# classes using the `generate_csharp_classes` method.
        """
        generator.generate_csharp_classes(test_data_root, schemas_dir, output_dir, quicktype_executable)
        angebot_file = output_dir / "bo" / "Angebot.cs"
        assert angebot_file.exists(), f"Expected file {angebot_file} was not generated"

    def test_generate_csharp_classes_snapshot(  # pylint: disable=too-many-arguments, too-many-positional-arguments
        self,
        test_data_root: Path,
        schemas_dir: Path,
        output_dir: Path,
        quicktype_executable: str,
        snapshot: SnapshotAssertion,
    ) -> None:
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

    def test_cli_main(self, schemas_dir: Path, output_dir: Path, snapshot: SnapshotAssertion) -> None:
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

    def test_error_handling_invalid_schemas_dir(
        self, test_data_root: Path, output_dir: Path, quicktype_executable: str
    ) -> None:
        """
        Test case for error handling when given an invalid schemas directory.
        """
        invalid_schemas_dir = test_data_root / "non_existent_dir"

        with pytest.raises(ValueError, match="Schemas directory does not exist"):
            generator.generate_csharp_classes(test_data_root, invalid_schemas_dir, output_dir, quicktype_executable)

    def test_generated_class_structure(
        self, test_data_root: Path, schemas_dir: Path, output_dir: Path, quicktype_executable: str
    ) -> None:
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


def test_cli_help() -> None:
    """
    Test case for CLI help message.
    """
    runner = CliRunner()
    result = runner.invoke(cli_app, ["--help"])
    assert result.exit_code == 0
    assert "Generate C# classes from the BO4E schema files" in result.output
