"""
Unit test class for the Generator module.
"""

import os
import platform
from pathlib import Path

from bo4egenerator import generator  # pylint: disable=wrong-import-position


class TestGenerator:
    """
    Unit test class for the Generator module.
    """

    def test_generate_csharp_classes(self) -> None:
        """
        Test case for generating C# classes using the `generate_csharp_classes` method.

        This test case verifies that the `generate_csharp_classes` method correctly generates C# classes.
        The Angebot schema file is used as an example for the test.
        It also checks if the generated `Angebot.cs` file exists in the output directory.
        """
        project_root = Path(__file__).parent / "test-data"
        schemas_dir = project_root / "schemas"
        output_dir = project_root / "generated-classes"
        quicktype_executable = "quicktype"  # Assuming it's in PATH on Linux (GH Actions)

        generator.generate_csharp_classes(project_root, schemas_dir, output_dir, quicktype_executable)

        angebot_file = Path(output_dir / "bo" / "Angebot.cs")
        assert angebot_file.exists()
