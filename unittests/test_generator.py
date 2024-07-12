"""
Unit test class for the Generator module.
"""

import os
import platform
import sys
import unittest
from pathlib import Path

sys.path.insert(0, str(Path(__file__).resolve().parents[1] / "src"))

from bo4egenerator import generator # pylint: disable=wrong-import-position

class TestGenerator(unittest.TestCase):
    """
    Unit test class for the Generator module.
    """

    def test_generate_csharp_classes(self):
        """
        Test case for generating C# classes using the `generate_csharp_classes` method.

        This test case verifies that the `generate_csharp_classes` method correctly generates C# classes.
        The Angebot schema file is used as an example for the test.
        It also checks if the generated `Angebot.cs` file exists in the output directory.
        """
        project_root = Path.cwd() / "unittests" / "test-data"
        schemas_dir = project_root / "schemas"
        output_dir = project_root / "generated-classes"
        # Determine the Quicktype executable path based on the operating system
        path_app_data = os.getenv("APPDATA")
        if platform.system() == "Windows" and path_app_data:
            quicktype_executable = os.path.join(path_app_data, "npm", "quicktype.cmd")
        else:
            quicktype_executable = "quicktype"  # Assuming it's in PATH on Linux (GH Actions)

        generator.generate_csharp_classes(project_root, schemas_dir, output_dir, quicktype_executable)

        angebot_file = Path(output_dir / "bo" / "Angebot.cs")
        assert angebot_file.exists()


if __name__ == "__main__":
    unittest.main()
