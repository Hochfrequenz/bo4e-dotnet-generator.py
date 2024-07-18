"""
contains CLI logic for bo4e-dotnet-generator.
this is the main entry point for the bo4e-generator. It generates C# classes from the BO4E schema files.
"""

import logging
import os
import platform
import shutil
from pathlib import Path

import typer

from bo4egenerator.configuration.log_setup import _logger
from bo4egenerator.duplicates import process_directory
from bo4egenerator.generator import generate_csharp_classes

app = typer.Typer(help="It generates C# classes from the BO4E schema files.")
_logger = logging.getLogger(__name__)


@app.command()
def main(
    schemas_dir: Path = typer.Argument(
        Path.cwd() / "schemas", help="Directory path containing the BO4E schema files."
    ),
    output: Path = typer.Option(
        Path.cwd() / "dotnet-classes", help="Output directory path for the generated C# classes. default: dotnet-classes"
    )
) -> None:
    """
    It generates C# classes from the BO4E schema files with help of Quicktype.

    args:
        output (Path): Output directory for the generated C# classes.
    """
    # Define the base directories
    project_root = Path.cwd()  # Root directory of the project
    generated_output_dir = project_root / "generated-dotnet-classes"

    # Determine the Quicktype executable path based on the operating system
    path_app_data = os.getenv("APPDATA")
    if platform.system() == "Windows" and path_app_data:
        quicktype_executable = os.path.join(path_app_data, "npm", "quicktype.cmd")
    else:
        quicktype_executable = "quicktype"  # Assuming it's in PATH on Linux (GH Actions)

    # Generate C# classes from the schemas
    generate_csharp_classes(project_root, schemas_dir, generated_output_dir, quicktype_executable)

    # Copy the generated files and subdirectories to the output directory
    if output.exists():
        shutil.rmtree(output)  # Remove existing output directory if it exists
    shutil.copytree(generated_output_dir, output)  # Copy the generated output to the final output directory

    # Remove duplicate class and enum definitions
    process_directory(output)


def cli() -> None:
    """entry point of the script defined in pyproject.toml"""
    # ⚠ If you ever change the name of this module (cli.py) or this function (def cli), be sure to update pyproject.toml
    app()


if __name__ == "__main__":
    _logger.info("Starting the script...")
    cli()
    _logger.info("Script execution completed.")
