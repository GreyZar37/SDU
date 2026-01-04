

from socket import *

serverPort = 12000

# Create a socket using TCP (SOCK_STREAM)
serverSocket = socket(AF_INET, SOCK_STREAM)

# Bind the socket to localhost:12000
serverSocket.bind(('localhost', serverPort))

# Listen for incoming connections
serverSocket.listen(1)
print('The server is ready to receive')

while True:
    # Accept connection from a client
    connectionSocket, clientAddress = serverSocket.accept()

    # Receive message from client
    message = connectionSocket.recv(2048)
    print('Received:', message.decode())

    modifiedMessage = message.upper()

    # Send message back to client
    connectionSocket.send(modifiedMessage)

    # Close connection to this client
    connectionSocket.close()
