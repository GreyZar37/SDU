#import socket module
import sys
from socket import *

serverName = '127.0.0.1'
serverPort = 11000

serverSocket = socket(AF_INET, SOCK_STREAM)


serverSocket.bind((serverName, serverPort))
serverSocket.listen(1)
print('The server is ready to receive')

while True:
    connectionSocket, clientAddress = serverSocket.accept()
    try:
        message = connectionSocket.recv(2048).decode()
        filename = message.split()[1]
        f = open(filename[1:])
        outputData = f.readlines()
        f.close()

        connectionSocket.send("HTTP/1.1 200 OK\r\n\r\n".encode())
        for i in range(1, len(outputData)):
            connectionSocket.send(outputData[i].encode())
        connectionSocket.close()
    except IOError:
        connectionSocket.send("HTTP/1.1 404 Not Found\r\n\r\n".encode())
        connectionSocket.send("<html><body><h1>404 Not Found</h1></body></html>".encode())
        connectionSocket.close()
