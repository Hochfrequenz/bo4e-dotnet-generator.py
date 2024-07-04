import subprocess
from pathlib import Path


def run_command(command: str, cwd: Path | None = None):
    result = subprocess.run(command, shell=True, cwd=cwd, text=True, capture_output=True)
    if result.returncode != 0:
        print(f"Command failed: {command}")
        print(result.stderr)
    return result


def install_bo4e_schema_tool():
    # the installation step of bost shall be done at this point, because bost is a dependency of this project
    run_command("bost -o ./schemas/")
    print("BO4E-Schema-Tool installation and schema downloading completed.")
