"""
It generates C# classes from the BO4E schema files with help od Quicktype npm package.
"""

import os
import subprocess
from pathlib import Path

from bo4egenerator.configuration.log_setup import _logger

def generate_csharp_classes(  # pylint: disable=too-many-locals
    project_root: Path, schemas_dir: Path, output_dir: Path, quicktype_executable: str
) -> None:
    """
    Generate C# classes from the BO4E schema files with help of Quicktype npm package.
    Args:
        project_root (Path): root path of the project
        schemas_dir (Path): path to the directory containing the BO4E schema files
        output_dir (Path): path to the directory where the generated C# BO classes will be saved
        quicktype_executable (str): path to the Quicktype executable
    """
    _logger.info("Starting C# class generation...")
    assert project_root.is_dir()
    assert schemas_dir.is_dir()

    # Change to the root directory of the project
    os.chdir(project_root)

    # Walk through the schema directory
    for root, _, files in os.walk(schemas_dir):
        for file in files:
            if file.endswith(".json"):
                # Construct the full path to the schema file
                schema_file = os.path.join(root, file)

                # Determine the relative path to preserve subfolder structure
                relative_path = os.path.relpath(root, schemas_dir)

                # Create corresponding subdirectory in the output directory
                output_subdir = os.path.join(output_dir, relative_path)
                if not os.path.exists(output_subdir):
                    os.makedirs(output_subdir)

                # Determine the output file path
                class_name = os.path.splitext(file)[0]
                output_file = os.path.join(output_subdir, f"{class_name}.cs")

                # Normalize paths to ensure correct format
                schema_file = os.path.normpath(schema_file)
                output_file = os.path.normpath(output_file)

                # Construct the quicktype command
                command = [
                    quicktype_executable,
                    "--src",
                    schema_file,
                    "--src-lang",
                    "schema",
                    "--out",
                    output_file,
                    "--lang",
                    "cs",
                    "--namespace",
                    "BO4EDotNet",
                ]

                # Debugging: Print the command to be executed
                _logger.info("Running command: %s", ' '.join(command))

                try:
                    # Execute the command
                    result = subprocess.run(command, cwd=root, check=True, capture_output=True, text=True)
                    _logger.info(result.stdout)
                except subprocess.CalledProcessError as e:
                    # Log the error and continue with the next file
                    _logger.error("Error running command: %s\n", ' '.join(command))
                    _logger.error("Error message: %s\n", e)
                    _logger.error("Standard Error Output: %s\n\n", e.stderr)
                    _logger.error("Error encountered. Logged and continuing with the next file.")

    _logger.info("C# classes generation completed. Check log file for any issues encountered.")
