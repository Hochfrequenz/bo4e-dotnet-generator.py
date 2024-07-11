import logging
from datetime import datetime
from pathlib import Path

# Define global log level
GLOBAL_LOG_LEVEL = logging.INFO

# Create a logger
_logger = logging.getLogger()
_logger.setLevel(GLOBAL_LOG_LEVEL)

# Ensure the logs directory exists
log_directory = Path(__file__).parent / ".logs"
log_directory.mkdir(exist_ok=True)

# Create a file handler that logs even debug messages
log_file_path = log_directory / f'{datetime.now().isoformat().replace(":", "").replace("+", "")}.log'
_filehandler = logging.FileHandler(log_file_path)
_filehandler.setLevel(GLOBAL_LOG_LEVEL)

# Create a formatter and set it for the handler
_LOG_FORMAT = "%(asctime)s - %(name)s - %(levelname)s - %(message)s"
formatter = logging.Formatter(_LOG_FORMAT)
_filehandler.setFormatter(formatter)

# Create a console handler
console_handler = logging.StreamHandler()
console_handler.setLevel(GLOBAL_LOG_LEVEL)
console_handler.setFormatter(formatter)

# Clear existing handlers
if _logger.hasHandlers():
    _logger.handlers.clear()

# Add the file and console handlers to the root logger
_logger.addHandler(_filehandler)
_logger.addHandler(console_handler)
