"""
tooling module contains helper functions for the bo4e-generator.
"""
import subprocess
from pathlib import Path


def run_command(command: str, cwd: Path | None = None) -> subprocess.CompletedProcess[str]:
    """
    Run a shell command and return the result.
    Args:
        command (str): command to run
        cwd (Path | None, optional): path. Defaults to None.

    Returns:
        subprocess.CompletedProcess[str]: _description_
    """
    result = subprocess.run(command, shell=True, cwd=cwd, text=True, capture_output=True, check=True)
    if result.returncode != 0:
        print(f"Command failed: {command}")
        print(result.stderr)
    return result


def install_bo4e_schema_tool() -> None:
    """
    the installation step of bost shall be done at this point, because bost is a dependency of this project
    """
    run_command("bost -o ./schemas/")
    print("BO4E-Schema-Tool installation and schema downloading completed.")
