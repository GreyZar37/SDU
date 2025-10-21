from socket import *
serverName = '10.125.73.154'
serverPort = 12000

#Create a socket using UDP (SOCK_DGRAM), AF_INET = IPv4 
clientSocket = socket(AF_INET, SOCK_DGRAM) #UDP

message = input('Input lowercase sentence:')

#Send messages to sender server
clientSocket.sendto(bytes(message,"utf-8"),(serverName, serverPort))

#wait for server to reply
modifiedMessage, serverAddress = clientSocket.recvfrom(2048)

print (modifiedMessage.decode())
clientSocket.close()
