"""
This module provides functionality to remove duplicate class and enum definitions from C# files.
It's designed to work with a specific project structure where classes and enums might be defined
in multiple files, and we want to keep only one instance of each.
"""

import logging
import os
import re
from pathlib import Path

from bo4egenerator.configuration.log_setup import _logger

_logger = logging.getLogger(__name__)

SINGLE_LINE_ENUM_PATTERN = re.compile(r"\s*public\s+enum\s+\w+\s*{[^}]*}\s*;")
CLASS_PATTERN = re.compile(r"\s*public\s+partial\s+class\s+(\w+)")
ENUM_PATTERN = re.compile(r"\s*public\s+enum\s+(\w+)")


class DuplicateRemover:
    """
    A class to handle the removal of duplicate class and enum definitions in C# files.

    This class provides methods to parse C# files, identify duplicate definitions,
    and remove them while preserving the main class in each file.
    """

    def __init__(self, directory_path: Path):
        """
        Initialize the DuplicateRemover with the directory to process.

        Args:
            directory_path (Path): The path to the directory containing C# files to process.
        """
        self.directory_path = directory_path

    def find_classes_and_enums_in_file(self, file_path: Path) -> tuple[list[str], list[str]]:
        """
        Find all class and enum definitions in a given file.

        Args:
            file_path (Path): The path to the file to analyze.

        Returns:
            tuple[list[str], list[str]]: A tuple containing two lists:
                - The first list contains the names of classes found in the file.
                - The second list contains the names of enums found in the file.
        """
        with file_path.open("r", encoding="utf-8") as file:
            content = file.read()
            classes = CLASS_PATTERN.findall(content)
            enums = ENUM_PATTERN.findall(content)

        _logger.debug("Classes found: %s", classes)
        _logger.debug("Enums found: %s", enums)
        return classes, enums

    @staticmethod
    def read_file(file_path: Path) -> list[str]:
        """
        Read the contents of a file.

        Args:
            file_path (Path): The path to the file to read.

        Returns:
            list[str]: A list of strings, where each string is a line from the file.
        """
        try:
            with file_path.open("r", encoding="utf-8") as file:
                return file.readlines()
        except OSError as e:
            _logger.error("Error reading file %s: %s", file_path, e)
            return []

    @staticmethod
    def write_file(file_path: Path, lines: list[str]) -> None:
        """
        Write content to a file.

        Args:
            file_path (Path): The path to the file to write.
            lines (list[str]): The content to write to the file, as a list of strings.
        """
        try:
            with file_path.open("w", encoding="utf-8") as file:
                file.writelines(lines)
        except OSError as e:
            _logger.error("Error writing to file %s: %s", file_path, e)

    @staticmethod
    def find_comment_block_start(lines: list[str], index: int) -> int:
        """
        Find the start of a comment block preceding a given line.

        Args:
            lines (list[str]): The lines of the file.
            index (int): The index of the line to start searching from.

        Returns:
            int: The index of the first line of the comment block, or the original index if no comment block is found.
        """
        while index > 0 and re.match(r"\s*///", lines[index - 1]):
            index -= 1
        return index

    def parse_definitions(self, lines: list[str], main_class_name: str) -> dict[str, tuple[int, int]]:
        """
        Parse class and enum definitions in the given lines.

        Args:
            lines (list[str]): The lines of the file to parse.
            main_class_name (str): The name of the main class in the file (which should not be removed).

        Returns:
            dict[str, tuple[int, int]]: A dictionary mapping definition names to their start and end line numbers.
        """
        definitions = {}
        in_definition = False
        current_definition = None
        comment_block_start_index = None

        for index, line in enumerate(lines):
            if re.match(r"\s*///", line) and not in_definition:
                if comment_block_start_index is None:
                    comment_block_start_index = index
                continue

            if comment_block_start_index is not None and not re.match(r"\s*///", line):
                comment_block_start_index = None

            if CLASS_PATTERN.match(line):
                class_name = CLASS_PATTERN.findall(line)[0]
                if class_name == main_class_name:
                    in_definition = False
                    continue

                current_definition = class_name
                in_definition = True
                definition_start_index = (
                    self.find_comment_block_start(lines, index) if comment_block_start_index is not None else index
                )

            elif ENUM_PATTERN.match(line):
                if SINGLE_LINE_ENUM_PATTERN.match(line):
                    enum_name = ENUM_PATTERN.findall(line)[0]
                    definition_start_index = (
                        self.find_comment_block_start(lines, index) if comment_block_start_index is not None else index
                    )
                    definitions[enum_name] = (definition_start_index, index)
                    _logger.debug(
                        "Single-line enum found: %s at lines %d to %d", enum_name, definition_start_index, index
                    )
                    continue

                enum_name = ENUM_PATTERN.findall(line)[0]
                current_definition = enum_name
                in_definition = True
                definition_start_index = (
                    self.find_comment_block_start(lines, index) if comment_block_start_index is not None else index
                )

            if in_definition and re.match(r"\s*\}", line):
                definitions[current_definition] = (definition_start_index, index)
                _logger.debug(
                    "Multi-line definition found: %s at lines %d to %d",
                    current_definition,
                    definition_start_index,
                    index,
                )
                in_definition = False

        return definitions

    @staticmethod
    def remove_definitions(
        lines: list[str], definitions: dict[str, tuple[int, int]], names_to_remove: list[str]
    ) -> list[str]:
        """
        Remove specified definitions from the given lines.

        Args:
            lines (list[str]): The lines of the file.
            definitions (dict[str, tuple[int, int]]): A dictionary mapping definition names
            to their start and end line numbers.
            names_to_remove (list[str]): A list of definition names to remove.

        Returns:
            list[str]: The lines of the file with specified definitions removed.
        """
        for name in names_to_remove:
            if name in definitions:
                start, end = definitions[name]
                while start > 0 and re.match(r"^\s*$", lines[start - 1]):
                    start -= 1
                while start > 0 and re.match(r"\s*///", lines[start - 1]):
                    start -= 1
                _logger.debug("Removing definition: %s from lines %d to %d", name, start, end)
                del lines[start : end + 1]
        return lines

    def remove_duplicate_definitions(
        self, file_path: Path, main_class_name: str, classes_to_remove: list[str], enums_to_remove: list[str]
    ) -> None:
        """
        Remove duplicate class and enum definitions from a file.

        Args:
            file_path (Path): The path to the file to process.
            main_class_name (str): The name of the main class in the file (which should not be removed).
            classes_to_remove (list[str]): A list of class names to remove.
            enums_to_remove (list[str]): A list of enum names to remove.
        """
        lines = self.read_file(file_path)
        if not lines:
            return

        definitions = self.parse_definitions(lines, main_class_name)
        lines = self.remove_definitions(lines, definitions, classes_to_remove + enums_to_remove)
        self.write_file(file_path, lines)

    def should_remove_class(self, class_name: str) -> bool:
        """
        Determine if a class should be removed based on the existence of its definition file.

        Args:
            class_name (str): The name of the class to check.

        Returns:
            bool: True if the class should be removed, False otherwise.
        """
        class_file_path_bo = self.directory_path / "bo" / f"{class_name}.cs"
        class_file_path_com = self.directory_path / "com" / f"{class_name}.cs"
        return class_file_path_bo.exists() or class_file_path_com.exists()

    def should_remove_enum(self, enum_name: str) -> bool:
        """
        Determine if an enum should be removed based on the existence of its definition file.

        Args:
            enum_name (str): The name of the enum to check.

        Returns:
            bool: True if the enum should be removed, False otherwise.
        """
        enum_file_path = self.directory_path / "enum" / f"{enum_name}.cs"
        return enum_file_path.exists()

    def process_file(self, file_path: Path) -> None:
        """
        Process a single file to remove duplicate class and enum definitions.

        Args:
            file_path (Path): The path to the file to process.
        """
        class_name_from_filename = file_path.stem
        classes_in_file, enums_in_file = self.find_classes_and_enums_in_file(file_path)

        classes_to_remove = [class_name for class_name in classes_in_file if class_name != class_name_from_filename]
        enums_to_remove = list(enums_in_file)

        for class_name in classes_to_remove:
            if self.should_remove_class(class_name):
                _logger.info("Removing class %s from %s", class_name, file_path)
                self.remove_duplicate_definitions(
                    file_path,
                    main_class_name=class_name_from_filename,
                    classes_to_remove=[class_name],
                    enums_to_remove=[],
                )

        for enum_name in enums_to_remove:
            if self.should_remove_enum(enum_name):
                _logger.info("Removing enum %s from %s", enum_name, file_path)
                self.remove_duplicate_definitions(
                    file_path,
                    main_class_name=class_name_from_filename,
                    classes_to_remove=[],
                    enums_to_remove=[enum_name],
                )

        _logger.info("Processed %s", file_path)

    def process_directory(self) -> None:
        """
        Process all .cs files in the directory to remove duplicate class and enum definitions.
        """
        for root, _, files in os.walk(self.directory_path):
            for filename in files:
                if filename.endswith(".cs"):
                    file_path = Path(root) / filename
                    self.process_file(file_path)


def remove_duplicate_definitions(directory_path: Path) -> None:
    """
    Remove duplicate class and enum definitions from all .cs files in the given directory.

    This function creates a DuplicateRemover instance and processes the entire directory.

    Args:
        directory_path (Path): The path to the directory containing C# files to process.
    """
    remover = DuplicateRemover(directory_path)
    remover.process_directory()
