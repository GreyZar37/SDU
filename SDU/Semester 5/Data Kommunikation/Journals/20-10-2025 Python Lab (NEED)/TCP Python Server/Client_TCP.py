from socket import *
import webbrowser

serverName = '127.0.0.1'
serverPort = 11000
fileName = 'HelloWorld.html'

# Create a TCP socket
clientSocket = socket(AF_INET, SOCK_STREAM)

# Connect to the server
clientSocket.connect((serverName, serverPort))

# Send a valid HTTP GET request
request = f"GET /{fileName} HTTP/1.1\r\nHost: {serverName}\r\n\r\n"
clientSocket.send(request.encode())

# Receive the response
response = b""
while True:
    data = clientSocket.recv(2048)
    if not data:
        break
    response += data

# Close the connection
clientSocket.close()

# Decode response and extract HTML body
response_str = response.decode()
header, _, body = response_str.partition("\r\n\r\n")
print(f"Response header: {body}")

# Save HTML to a temporary file
output_file = "received_page.html"
with open(output_file, "w", encoding="utf-8") as f:
    f.write(body)

print(f"Saved HTML content to {output_file}")
webbrowser.open(output_file)
