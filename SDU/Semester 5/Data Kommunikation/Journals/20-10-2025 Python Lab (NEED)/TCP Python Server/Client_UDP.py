from socket import *
serverName = 'localhost'
serverPort = 12000

clientSocket = socket(AF_INET, SOCK_DGRAM)

message = input('Input lowercase sentence:')

#Send messages to sender server
clientSocket.sendto(bytes(message,"utf-8"),(serverName, serverPort))

#wait for server to reply
modifiedMessage, serverAddress = clientSocket.recvfrom(2048)

print (modifiedMessage.decode())
clientSocket.close()

