using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Web;
using System.Data;

namespace ServerTest
{
    class Server
    {
        static void Main(string[] args)
        {
            // Set up the HTTP listener
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:8080/");
            listener.Start();
            Console.WriteLine("Listening for connections on port 8080");
            while (true)
            {
                try
                {
                    HttpListenerContext context = listener.GetContext();
                    string path = context.Request.Url.AbsolutePath;

                    if (context.Request.HttpMethod == "POST")
                    {
                        string jsonRequestData = ReadRequestBody(context.Request.InputStream);
                        var fromDataValues = HttpUtility.ParseQueryString(jsonRequestData);

                        MySqlCommand cmd;
                        JsonDocument requestData;
                        try
                        {
                            requestData = JsonDocument.Parse(jsonRequestData);
                        }
                        catch (JsonException)
                        {
                            context.Response.StatusCode = 400; // Bad Request
                            SendResponse(context, "Invalid JSON format.");
                            continue;
                        }

                        switch (path)
                        {
                            case "/register":
                                if (requestData.RootElement.TryGetProperty("username", out JsonElement usernameElement) &&
                                    requestData.RootElement.TryGetProperty("password", out JsonElement passwordElement))
                                {
                                    string username = usernameElement.GetString();
                                    string password = passwordElement.GetString();
                                    SendResponse(context, $"Reached register endpoint: {username} {password}");
                                }
                                else
                                {
                                    context.Response.StatusCode = 400; // Bad Request
                                    SendResponse(context, "Missing username or password in JSON.");
                                }
                                break;

                            case "/login":
                                if (requestData.RootElement.TryGetProperty("username", out JsonElement loginUsernameElement) &&
                                    requestData.RootElement.TryGetProperty("password", out JsonElement loginPasswordElement))
                                {
                                    string loginUsername = loginUsernameElement.GetString();
                                    string loginPassword = loginPasswordElement.GetString();
                                    SendResponse(context, $"Reached login endpoint: {loginUsername} {loginPassword}");
                                }
                                else
                                {
                                    context.Response.StatusCode = 400; // Bad Request
                                    SendResponse(context, "Missing username or password in JSON.");
                                }
                                break;

                            default:
                                context.Response.StatusCode = 404;
                                SendResponse(context, "Endpoint not found: " + path);
                                break;
                        }
                    }
                    else if (context.Request.HttpMethod == "GET")
                    {
                        switch (path)
                        {
                            case "/register":
                                ServerStaticHtmlFile(context, "Register.html");
                                break;
                            case "/login":
                                ServerStaticHtmlFile(context, "Login.html");
                                break;
                            default:
                                ServerStaticHtmlFile(context, "Home.html");
                                break;
                        }
                    }
                    else
                    {
                        context.Response.StatusCode = 405; // Method Not Allowed
                        SendResponse(context, "Method not allowed: " + context.Request.HttpMethod);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        private static void SendResponse(HttpListenerContext context, string responseString, string contentType = "text/plain")
        {
            byte[] buffer = Encoding.UTF8.GetBytes(responseString);
            context.Response.ContentLength64 = buffer.Length;
            context.Response.ContentType = contentType;
            context.Response.OutputStream.Write(buffer, 0, buffer.Length);
            context.Response.OutputStream.Close(); // Properly close the stream
            context.Response.Close(); // Properly close the context
        }

        static string ReadRequestBody(Stream inputStream)
        {
            using (StreamReader reader = new StreamReader(inputStream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }

        static void ServerStaticHtmlFile(HttpListenerContext context, string fileName)
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, "HtmlPages", fileName);
            Console.WriteLine($"Attempting to access file at: {filePath}");
            if (File.Exists(filePath))
            {
                string htmlContent = File.ReadAllText(filePath, Encoding.UTF8);
                SendResponse(context, htmlContent, "text/html");
            }
            else
            {
                context.Response.StatusCode = 404;
                SendResponse(context, "File not found: " + filePath);
            }
        }
    }
}
