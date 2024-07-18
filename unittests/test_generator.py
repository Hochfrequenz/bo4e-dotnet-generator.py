"""
Unit test class for the Generator module.
"""

from pathlib import Path

from bo4egenerator import generator


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
        test_data_root = Path(__file__).parent / "test-data"
        schemas_dir = test_data_root / "schemas"
        output_dir = test_data_root / "generated-classes"
        quicktype_executable = "quicktype"  # Assuming it's in PATH on Linux (GH Actions)

        generator.generate_csharp_classes(test_data_root, schemas_dir, output_dir, quicktype_executable)

        angebot_file = Path(output_dir / "bo" / "Angebot.cs")
        assert angebot_file.exists()
