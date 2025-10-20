
#Simple Python script to print Hello World
"""
print('Hello World')
"""

# Printing the system time of my computer in the format: hh:mm:ss
"""
import time
current_time = time.strftime("%H:%M:%S", time.localtime())
print("Current Time =", current_time)

# Input a message with a timestamp

from datetime import datetime

message = input("Enter your message: ")

timestamp = datetime.now().strftime("%Y-%m-%d %H:%M:%S")

with open("log.txt", "a") as logfile: logfile.write(f"{timestamp} - {message}\n")

print("Message saved to log.txt")

# User can use command line argument
"""
"""
import sys
from datetime import datetime

if len(sys.argv) > 1:
    message = " ".join(sys.argv[1:])
else:
    message = input("Enter your message: ")

timestamp = datetime.now().strftime("%Y-%m-%d %H:%M:%S")

with open("log.txt", "a") as logfile:
    logfile.write(f"{timestamp} - {message}\n")

print("Message saved to log.txt")
"""

# Expand the program to print all logged messages with timestamps


import sys
from datetime import datetime

if len(sys.argv) > 1:
    message = " ".join(sys.argv[1:])
else:
    message = input("Enter your message: ")

timestamp = datetime.now().strftime("%Y-%m-%d %H:%M:%S")

with open("log.txt", "a") as logfile:
    logfile.write(f"{timestamp} - {message}\n")

print("Message saved to log.txt\n")

print("=== Log Contents ===")
with open("log.txt", "r") as logfile:
    for line in logfile:
        print(line, end="")
