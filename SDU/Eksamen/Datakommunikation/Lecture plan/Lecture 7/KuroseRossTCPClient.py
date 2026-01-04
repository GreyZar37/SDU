


from socket import *

serverName = 'localhost'
serverPort = 12000

# Create a socket using TCP (SOCK_STREAM), AF_INET = IPv4
clientSocket = socket(AF_INET, SOCK_STREAM)  # TCP

# Connect to the server (TCP needs a connection)
clientSocket.connect((serverName, serverPort))

message = input('Input lowercase sentence:')

# Send message to server
clientSocket.send(bytes(message, "utf-8"))

# Wait for server to reply
modifiedMessage = clientSocket.recv(2048)

print(modifiedMessage.decode())
clientSocket.close()

