"""
contains CLI logic for bo4egenerator.
this is the main entry point for the bo4e-generator. It generates C# classes from the BO4E schema files.
"""

import os
import platform
from pathlib import Path

import typer

from bo4egenerator.generator import generate_csharp_classes
from bo4egenerator.tooling import install_bo4e_schema_tool

app = typer.Typer(help="It generates C# classes from the BO4E schema files.")


@app.command()
def main() -> None:
    """
    It will install the BO4E-Schema-Tool and
    generate C# classes from the BO4E schema files with help of Quicktype.
    """
    # Define the base directories
    project_root = os.path.abspath(os.path.dirname(__file__))  # Root directory of the project
    schemas_dir = os.path.join(project_root, "schemas")
    output_dir = os.path.join(project_root, "dotnet-classes")

    # Determine the Quicktype executable path based on the operating system
    path_app_data = os.getenv("APPDATA")
    if platform.system() == "Windows" and path_app_data:
        quicktype_executable = os.path.join(path_app_data, "npm", "quicktype.cmd")
    else:
        quicktype_executable = "quicktype"  # Assuming it's in PATH on Linux (GH Actions)

    # Install BO4E-Schema-Tool and generate schemas
    install_bo4e_schema_tool(schemas_dir)

    # Generate C# classes
    generate_csharp_classes(Path(project_root), Path(schemas_dir), Path(output_dir), quicktype_executable)


if __name__ == "__main__":
    print("Starting the script...")
    main()
    print("Script execution completed.")