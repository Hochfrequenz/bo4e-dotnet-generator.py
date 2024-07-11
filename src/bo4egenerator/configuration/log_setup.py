import logging
from datetime import datetime
from pathlib import Path

# Define global log level
GLOBAL_LOG_LEVEL = logging.INFO

# Create a logger
_logger = logging.getLogger(__name__)
_logger.setLevel(GLOBAL_LOG_LEVEL)

# Ensure the logs directory exists
log_directory = Path(__file__).parent / "logs"
log_directory.mkdir(exist_ok=True)

# Create a file handler that logs even debug messages
log_file_path = log_directory / f'{datetime.now().isoformat().replace(":", "").replace("+", "")}.log'
_filehandler = logging.FileHandler(log_file_path)
_filehandler.setLevel(GLOBAL_LOG_LEVEL)

# Create a formatter and set it for the handler
_LOG_FORMAT = "%(asctime)s - %(name)s - %(levelname)s - %(message)s"
formatter = logging.Formatter(_LOG_FORMAT)
_filehandler.setFormatter(formatter)

# Add the file handler to the logger
_logger.addHandler(_filehandler)

# Create a console handler
console_handler = logging.StreamHandler()
console_handler.setLevel(GLOBAL_LOG_LEVEL)
console_handler.setFormatter(formatter)

# Add the console handler to the logger
_logger.addHandler(console_handler)

# Configure the basic logging settings
logging.basicConfig(level=GLOBAL_LOG_LEVEL, format=_LOG_FORMAT, handlers=[_filehandler, console_handler])
