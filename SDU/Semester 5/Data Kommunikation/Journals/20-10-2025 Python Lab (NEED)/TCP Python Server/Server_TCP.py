from socket import *
from time import sleep
import time
serverPort = 11000


# Create a TCP socket
serverSocket = socket(AF_INET, SOCK_STREAM)

# Bind to address and port
serverSocket.bind(('localhost', serverPort))

# Listen for incoming connections (max 1 pending connection)
serverSocket.listen(1)

print('The server is ready to receive')

while True:
    # Accept a TCP connection
    connectionSocket, clientAddress = serverSocket.accept()
    print(f"Connection established with {clientAddress}")


    # Receive data from the client
    message = connectionSocket.recv(2048).decode()
    print('Received:', message)

    # Process the request with status updates
    for i in range(3):
        wait_msg = f"please wait {i}"
        connectionSocket.send(wait_msg.encode())
        print(wait_msg)
        time.sleep(5)


    # Send final response
    modifiedMessage = message.upper()
    connectionSocket.send(modifiedMessage.encode())

    # Close connection after response
    connectionSocket.close()