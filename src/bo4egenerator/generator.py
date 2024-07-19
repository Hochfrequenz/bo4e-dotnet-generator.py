"""
This module generates C# classes from BO4E schema files using the Quicktype npm package.
It provides functionality to process JSON schema files and create corresponding C# class files.
"""

import logging
import os
import subprocess
from pathlib import Path
from typing import List

from bo4egenerator.configuration.log_setup import _logger

_logger = logging.getLogger(__name__)


class CSharpClassGenerator:
    """
    A class to handle the generation of C# classes from BO4E schema files.
    """

    def __init__(self, project_root: Path, schemas_dir: Path, output_dir: Path, quicktype_executable: str):
        """
        Initialize the CSharpClassGenerator.

        Args:
            project_root (Path): Root path of the project.
            schemas_dir (Path): Path to the directory containing the BO4E schema files.
            output_dir (Path): Path to the directory where the generated C# BO classes will be saved.
            quicktype_executable (str): Path to the Quicktype executable.
        """
        self.project_root = project_root
        self.schemas_dir = schemas_dir
        self.output_dir = output_dir
        self.quicktype_executable = quicktype_executable

    def generate_classes(self) -> None:
        """
        Generate C# classes from the BO4E schema files.
        """
        _logger.info("Starting C# class generation...")
        self._validate_directories()
        os.chdir(self.project_root)

        for schema_file in self._get_schema_files():
            self._process_schema_file(schema_file)

        _logger.info("C# classes generation completed. Check log file for any issues encountered.")

    def _validate_directories(self) -> None:
        """
        Validate that the required directories exist.
        """
        if not self.project_root.is_dir():
            raise ValueError(f"Project root directory does not exist: {self.project_root}")
        if not self.schemas_dir.is_dir():
            raise ValueError(f"Schemas directory does not exist: {self.schemas_dir}")

    def _get_schema_files(self) -> List[Path]:
        """
        Get a list of all JSON schema files in the schemas directory.

        Returns:
            List[Path]: A list of paths to JSON schema files.
        """
        return [
            Path(os.path.join(root, file))
            for root, _, files in os.walk(self.schemas_dir)
            for file in files
            if file.endswith(".json")
        ]

    def _process_schema_file(self, schema_file: Path) -> None:
        """
        Process a single schema file to generate a C# class.

        Args:
            schema_file (Path): Path to the schema file to process.
        """
        relative_path = schema_file.relative_to(self.schemas_dir).parent
        output_subdir = self.output_dir / relative_path
        output_subdir.mkdir(parents=True, exist_ok=True)

        class_name = schema_file.stem
        output_file = output_subdir / f"{class_name}.cs"

        command = self._build_quicktype_command(schema_file, output_file)
        self._run_quicktype_command(command, schema_file.parent)

    def _build_quicktype_command(self, schema_file: Path, output_file: Path) -> List[str]:
        """
        Build the Quicktype command for generating a C# class.

        Args:
            schema_file (Path): Path to the input schema file.
            output_file (Path): Path to the output C# file.

        Returns:
            List[str]: The Quicktype command as a list of strings.
        """
        return [
            self.quicktype_executable,
            "--src",
            str(schema_file),
            "--src-lang",
            "schema",
            "--out",
            str(output_file),
            "--lang",
            "cs",
            "--namespace",
            "BO4EDotNet",
        ]

    def _run_quicktype_command(self, command: List[str], cwd: Path) -> None:
        """
        Run the Quicktype command and handle any errors.

        Args:
            command (List[str]): The Quicktype command to run.
            cwd (Path): The current working directory for the command.
        """
        _logger.info("Running command: %s", " ".join(command))
        try:
            result = subprocess.run(command, cwd=cwd, check=True, capture_output=True, text=True)
            _logger.info(result.stdout)
        except subprocess.CalledProcessError as e:
            _logger.error("Error running command: %s", " ".join(command))
            _logger.error("Error message: %s", e)
            _logger.error("Standard Error Output: %s", e.stderr)
            _logger.error("Error encountered. Logged and continuing with the next file.")


def generate_csharp_classes(project_root: Path, schemas_dir: Path, output_dir: Path, quicktype_executable: str) -> None:
    """
    Generate C# classes from the BO4E schema files with help of Quicktype npm package.

    Args:
        project_root (Path): Root path of the project.
        schemas_dir (Path): Path to the directory containing the BO4E schema files.
        output_dir (Path): Path to the directory where the generated C# BO classes will be saved.
        quicktype_executable (str): Path to the Quicktype executable.
    """
    generator = CSharpClassGenerator(project_root, schemas_dir, output_dir, quicktype_executable)
    generator.generate_classes()
