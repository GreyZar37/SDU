

from socket import *

serverName = 'localhost'
serverPort = 11000

# Create a TCP socket
clientSocket = socket(AF_INET, SOCK_STREAM)

# Connect to the server
clientSocket.connect((serverName, serverPort))

message = input('Input lowercase sentence: ')
clientSocket.send(message.encode())

for i in range(3):
    wait_msg = clientSocket.recv(2048).decode()
    print("From Server:", wait_msg)

# Receive modified (uppercase) message
modifiedMessage = clientSocket.recv(2048)
print('From Server:', modifiedMessage.decode())

# Close the connection
clientSocket.close()
