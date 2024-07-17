"""
Remove duplicate class and enum definitions from the generated files.
"""

import logging
import os
import re
from pathlib import Path

from bo4egenerator.configuration.log_setup import _logger

_logger = logging.getLogger(__name__)

single_line_enum_pattern = re.compile(r"\s*public\s+enum\s+\w+\s*{[^}]*}\s*;")
class_pattern = re.compile(r"\s*public\s+partial\s+class\s+(\w+)")
enum_pattern = re.compile(r"\s*public\s+enum\s+(\w+)")


def find_classes_and_enums_in_file(file_path: Path) -> tuple[list[str], list[str]]:
    """
    Find all partial class and enum definitions in a given file.

    Args:
        file_path (Path): The path to the file.

    Returns:
        tuple: Two lists containing class names and enum names found in the file.
    """

    classes, enums = [], []
    with file_path.open("r", encoding="utf-8") as file:
        content = file.read()
        classes = class_pattern.findall(content)
        enums = enum_pattern.findall(content)

    _logger.debug("Classes found: %s", classes)
    _logger.debug("Enums found: %s", enums)
    return classes, enums


def read_file(file_path: Path) -> list[str]:
    """
    read the file and return the lines.
    """
    try:
        with file_path.open("r", encoding="utf-8") as file:
            return file.readlines()
    except OSError as e:
        _logger.error("Error reading file %s: %s", file_path, e)
        return []


def write_file(file_path: Path, lines: list[str]) -> None:
    """
    write the lines to the file.
    """
    try:
        with file_path.open("w", encoding="utf-8") as file:
            file.writelines(lines)
    except OSError as e:
        _logger.error("Error writing to file %s: %s", file_path, e)


def find_comment_block_start(lines: list[str], index: int) -> int:
    """
    find the start of the docstring block.
    """
    while index > 0 and re.match(r"\s*///", lines[index - 1]):
        index -= 1
    return index


def parse_definitions(lines: list[str], main_class_name: str) -> dict[str, tuple[int, int]]:
    """
    Parse the definitions of the classes and enums in the file.
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

        if re.match(class_pattern, line):
            class_name = re.findall(class_pattern, line)[0]
            if class_name == main_class_name:
                in_definition = False
                continue

            current_definition = class_name
            in_definition = True
            definition_start_index = (
                find_comment_block_start(lines, index) if comment_block_start_index is not None else index
            )

        elif re.match(enum_pattern, line):
            if single_line_enum_pattern.match(line):
                enum_name = re.findall(enum_pattern, line)[0]
                definition_start_index = (
                    find_comment_block_start(lines, index) if comment_block_start_index is not None else index
                )
                definitions[enum_name] = (definition_start_index, index)
                _logger.debug("Single-line enum found: %s at lines %d to %d", enum_name, definition_start_index, index)
                continue

            enum_name = re.findall(enum_pattern, line)[0]
            current_definition = enum_name
            in_definition = True
            definition_start_index = (
                find_comment_block_start(lines, index) if comment_block_start_index is not None else index
            )

        if in_definition and re.match(r"\s*\}", line):
            definitions[current_definition] = (definition_start_index, index)
            _logger.debug(
                "Multi-line definition found: %s at lines %d to %d", current_definition, definition_start_index, index
            )
            in_definition = False

    return definitions


def remove_definitions(
    lines: list[str], definitions: dict[str, tuple[int, int]], names_to_remove: list[str]
) -> list[str]:
    """
    Remove the definitions of the classes and enums that are not needed.
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


def remove_duplicate_definitions(  # pylint: disable=too-many-locals, too-many-branches, too-many-statements
    file_path: Path, main_class_name: str, classes_to_remove: list[str], enums_to_remove: list[str]
) -> None:
    """_summary_
    remove the duplicate definitions from the file, keeping the main class.
    """
    lines = read_file(file_path)
    if not lines:
        return

    definitions = parse_definitions(lines, main_class_name)
    lines = remove_definitions(lines, definitions, classes_to_remove + enums_to_remove)
    write_file(file_path, lines)


def should_remove_class(class_name: str, directory_path: Path) -> bool:
    """
    make sure if there is a .cs file for that? if there is, then remove it.
    """
    class_file_path_bo = directory_path / "bo" / f"{class_name}.cs"
    class_file_path_com = directory_path / "com" / f"{class_name}.cs"
    return class_file_path_bo.exists() or class_file_path_com.exists()


def should_remove_enum(enum_name: str, directory_path: Path) -> bool:
    """
    make sure if there is a .cs file for that? if there is, then remove it.
    """
    enum_file_path = directory_path / "enum" / f"{enum_name}.cs"
    return enum_file_path.exists()


def process_file(file_path: Path, directory_path: Path) -> None:
    """
    iterate over the file and remove the classes and enums that are not needed.
    """
    class_name_from_filename = file_path.stem
    classes_in_file, enums_in_file = find_classes_and_enums_in_file(file_path)

    classes_to_remove = [class_name for class_name in classes_in_file if class_name != class_name_from_filename]
    enums_to_remove = list(enums_in_file)

    for class_name in classes_to_remove:
        if should_remove_class(class_name, directory_path):
            _logger.info("Removing class %s from %s", class_name, file_path)
            remove_duplicate_definitions(
                file_path,
                main_class_name=class_name_from_filename,
                classes_to_remove=[class_name],
                enums_to_remove=[],
            )

    for enum_name in enums_to_remove:
        if should_remove_enum(enum_name, directory_path):
            _logger.info("Removing enum %s from %s", enum_name, file_path)
            remove_duplicate_definitions(
                file_path,
                main_class_name=class_name_from_filename,
                classes_to_remove=[],
                enums_to_remove=[enum_name],
            )

    _logger.info("Processed %s", file_path)


def process_directory(directory_path: Path) -> None:
    """
    Process all files in the directory to remove duplicate class and enum definitions.

    Args:
        directory_path (Path): The path to the output directory.
    """
    for root, _, files in os.walk(directory_path):
        for filename in files:
            if filename.endswith(".cs"):
                file_path = Path(root) / filename
                process_file(file_path, directory_path)
