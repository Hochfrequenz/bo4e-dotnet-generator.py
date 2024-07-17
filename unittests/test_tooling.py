"""
Test the tooling module.
"""

import sys
import unittest
from pathlib import Path
from unittest.mock import MagicMock, patch

from bo4egenerator import tooling

sys.path.insert(0, str(Path(__file__).resolve().parents[1] / "src"))


class TestTooling(unittest.TestCase):
    """
    A test case for the Tooling class.
    """

    @patch("subprocess.run")
    def test_run_command(self, mock_run):
        """
        Test the run_command method.

        This method tests the run_command method of the tooling module.
        It mocks the run method and asserts that the run_command method
        is called with the correct arguments. It also checks the return
        code of the run_command method.

        Args:
            mock_run: The mocked run method.

        Returns:
            None

        Raises:
            AssertionError: If the run_command method is not called with
                the correct arguments or if the return code is not 0.
        """
        mock_run.return_value = MagicMock(returncode=0)
        result = tooling.run_command("echo test", cwd=Path("."))
        mock_run.assert_called_once_with(
            "echo test", shell=True, cwd=Path("."), text=True, capture_output=True, check=True
        )
        self.assertEqual(result.returncode, 0)


if __name__ == "__main__":
    unittest.main()
