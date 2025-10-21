from socket import *

serverPort = 12000

#Create a socket using UDP (SOCK_DGRAM)
serverSocket = socket(AF_INET, SOCK_DGRAM)

#bind the socket to localhost:12000
serverSocket.bind(( 'localhost', serverPort))
print ('The server is ready to receive')
while 1:
    #Wait for messages
    message, clientAddress = serverSocket.recvfrom(2048)

    print('Received: ' + str(message.decode()))
    modifiedMessage = message.upper()

    #Send messages back to sender
    serverSocket.sendto(modifiedMessage, clientAddress)
