import shutil
from pathlib import Path
from typing import Generator

import pytest

from bo4egenerator import duplicates

# sys.path.insert(
#    0, str(Path(__file__).resolve().parents[1] / "src")
# )  # it is needed just one time to be able to import the module
# You don't need this. Follow the instructions from the python-template repository.
# You have to mark the src directory as a source root (blue) in PyCharm + the unittests directory as a test root (green)


class TestRemoveDuplicateDefinitions:
    """
    test case for removing duplicate class and enum definitions from C# files.
    """

    @pytest.fixture
    def output_dir(self, tmp_path) -> Generator[Path, None, None]:
        """Copy the generated classes to the temporary directory."""
        test_data_root = Path(__file__).parent / "test-data"
        # Path to the source directory containing the generated C# files with quicktype
        source_dir = test_data_root / "generated-classes"
        # Path to the temporary directory where the processed files will be saved
        output_dir = tmp_path / "dotnet-classes"
        output_dir.mkdir(exist_ok=True)
        shutil.copytree(source_dir, output_dir, dirs_exist_ok=True)
        yield output_dir

    def test_remove_duplicate_definitions_with_setup_and_teardown(self, output_dir) -> None:
        """
        Test case for removing duplicate class and enum definitions from C# files using setup and teardown.
        """
        # Set up the test environment
        test_data_root = Path(__file__).parent / "test-data"
        source_dir = test_data_root / "generated-classes"
        shutil.copytree(source_dir, output_dir, dirs_exist_ok=True)

        # Run the process_directory function on the test directory
        duplicates.process_directory(Path(output_dir))

        # Verify that duplicate class and enum definitions are removed
        bo_file_path = output_dir / Path("bo") / Path("Angebot.cs")
        with open(bo_file_path, "r", encoding="utf-8") as file:
            bo_content = file.read()

        com_file_path = output_dir / Path("com") / Path("Adresse.cs")
        with open(com_file_path, "r", encoding="utf-8") as file:
            com_content = file.read()

        # Check that "public enum Typ" is not in Angebot.cs
        assert "public enum Typ" not in bo_content, "`public enum Typ` should have been removed from Angebot.cs"

        # Check that "public enum Landescode" is not in Adresse.cs
        assert (
            "public enum Landescode" not in com_content
        ), "`public enum Landescode` should have been removed from Adresse.cs"
