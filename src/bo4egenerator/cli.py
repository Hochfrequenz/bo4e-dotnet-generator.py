import os
import platform

from bo4egenerator.generator import generate_csharp_classes
from bo4egenerator.tooling import install_bo4e_schema_tool


def main():
    # Define the base directories
    project_root = os.path.abspath(os.path.dirname(__file__))  # Root directory of the project
    schemas_dir = os.path.join(project_root, "schemas")
    output_dir = os.path.join(project_root, "dotnet-classes")

    # Determine the Quicktype executable path based on the operating system
    if platform.system() == "Windows":
        quicktype_executable = os.path.join(os.getenv("APPDATA"), "npm", "quicktype.cmd")
    else:
        quicktype_executable = "quicktype"  # Assuming it's in PATH on Linux (GH Actions)

    # Install BO4E-Schema-Tool and generate schemas
    install_bo4e_schema_tool()

    # Generate C# classes
    generate_csharp_classes(project_root, schemas_dir, output_dir, quicktype_executable)


if __name__ == "__main__":
    print("Starting the script...")
    main()
    print("Script execution completed.")
