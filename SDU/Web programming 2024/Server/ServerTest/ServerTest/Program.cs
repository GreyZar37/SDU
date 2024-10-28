using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Web;
using MySql.Data.MySqlClient;
using MySqlConnector;
using MySqlCommand = MySql.Data.MySqlClient.MySqlCommand;
using MySqlConnection = MySql.Data.MySqlClient.MySqlConnection;

namespace ServerTest
{
    class Server
    {
        const string d_username = "root";
        const string d_password = "1";
        const string database = "test";
        const string server = "localhost";
        static async Task Main(string[] args)
        {
            // Set up the HTTP listener
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:8080/");
            listener.Start();
            
            string ConnectionString = $"Server={server};Database={database};Uid={d_username};Pwd={d_password};";
            await using var conn = new MySqlConnection(ConnectionString);
            await conn.OpenAsync();
        
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
                        string connStr = "Server=your_server_address;Database=your_database;User=your_username;Password=your_password;";

                        switch (path)
                        {
                            case "/register":
                                string username = fromDataValues.Get("username");
                                string password = fromDataValues.Get("password");
                                string insertQuery = $"INSERT INTO users (username, password) VALUES ('{username}', '{password}')";
                                cmd = new MySqlCommand(insertQuery, conn);
                                cmd.Parameters.AddWithValue("@username", username);
                                cmd.Parameters.AddWithValue("@password", password);
                                
                                if(cmd.ExecuteNonQuery() > 0)
                                {
                                    SendResponse(context, "User registered successfully");
                                    ServerStaticHtmlFile(context, "Login.html");
                                }
                                else
                                {
                                    SendResponse(context, "Failed to register user");
                                }
                                break;

                            case "/login":
                              
                                break;
                            case "/logout":
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
