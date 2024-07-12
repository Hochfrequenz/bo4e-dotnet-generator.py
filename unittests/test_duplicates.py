import sys
import unittest
import shutil
import os
from pathlib import Path
from tempfile import TemporaryDirectory

sys.path.insert(0, str(Path(__file__).resolve().parents[1] / "src"))

from bo4egenerator import duplicates

class TestRemoveDuplicateDefinitions(unittest.TestCase):

    def setUp(self):
        self.temp_dir = TemporaryDirectory()

        project_root = Path.cwd() / "unittests" / "test-data"
        # Path to the source directory containing the generated C# files with quicktype
        self.source_dir = project_root / 'generated-classes'
        # Path to the temporary directory where the processed files will be saved
        self.output_dir = Path(self.temp_dir.name) / 'dotnet-classes'
        shutil.copytree(self.source_dir, self.output_dir, dirs_exist_ok=True)

    def tearDown(self):
        self.temp_dir.cleanup()

    def test_remove_duplicate_definitions(self):
        # Run the process_directory function on the test directory
        duplicates.process_directory(self.output_dir)
        
        # Verify that duplicate class and enum definitions are removed
        bo_file_path = Path(self.output_dir) / 'bo' / 'Angebot.cs'
        with open(bo_file_path, "r", encoding="utf-8") as file:
            bo_content = file.read()

        com_file_path = Path(self.output_dir) / 'com' / 'Adresse.cs'
        with open(com_file_path, "r", encoding="utf-8") as file:
            com_content = file.read()

        # Check that "public enum Typ" is not in Angebot.cs
        self.assertNotIn("public enum Typ", bo_content, "`public enum Typ` should have been removed from Angebot.cs")

        # Check that "public enum Landescode" is not in Adresse.cs
        self.assertNotIn("public enum Landescode", com_content, "`public enum Landescode` should have been removed from Adresse.cs")

if __name__ == '__main__':
    unittest.main()