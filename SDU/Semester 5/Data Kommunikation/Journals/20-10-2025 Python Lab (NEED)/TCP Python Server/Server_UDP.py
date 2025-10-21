from socket import *

serverPort = 12000

serverSocket = socket(AF_INET, SOCK_DGRAM)

serverSocket.bind(( 'localhost', serverPort))
print ('The server is ready to receive')
while 1:
    #Wait for messages
    message, clientAddress = serverSocket.recvfrom(2048)

    print('Received: ' + str(message.decode()))
    modifiedMessage = message.upper()

    #Send messages back to sender
    serverSocket.sendto(modifiedMessage, clientAddress)
