using System.Net;
using System.Net.Sockets;
using System.Text;

namespace WebServer.HTTP
{
    public class HttpServer : IHttpServer
    {
        public async Task StartAsync(int port)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, port);
            tcpListener.Start();
            while (true)
            {
                TcpClient client = await tcpListener.AcceptTcpClientAsync();
                ProcessClientAsync(client);
            }
        }   

        private async Task ProcessClientAsync(TcpClient tcpClient)
        {
            try
            {
                using NetworkStream stream = tcpClient.GetStream();

                int position = 0;
                byte[] buffer = new byte[HttpConstants.BufferSize];
                List<byte> data = new List<byte>();
                
                // Reading buffer from the stream
                while (true)
                {
                    int count = await stream.ReadAsync(buffer, position, buffer.Length);
                    position += count;

                    if (count < buffer.Length)
                    {
                        var tempBuffer = new byte[count];
                        Array.Copy(buffer, tempBuffer, count);
                        data.AddRange(tempBuffer);
                        break;
                    }
                    else
                    {
                        data.AddRange(buffer);
                    }


                    if (count == 0)
                    {
                        break;
                    }
                }

                // Encoding byte[] => string
                var requestAsString = Encoding.UTF8.GetString(data.ToArray());
                var request = new HttpRequest(requestAsString);
                Console.WriteLine($"{request.Method} {request.Path} => " +
                                  $"\nHeaders Count:{request.Headers.Count} " +
                                  $"\nCookies:\n{string.Join("\n", request.Cookies.Select(x => x))}\n");

                // Response
                string responseHtml = $"<h1>Welcome {DateTime.UtcNow}</h1>";
                byte[] responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);

                HttpResponse response = new HttpResponse("text/html", responseBodyBytes);
                response.Headers.Add(new Header("Server", "WebServer 1.1"));
                response.Cookies.Add(new ResponseCookie("sid", Guid.NewGuid().ToString()) {HttpOnly = true, MaxAge = 5 * 24 * 60 * 60} );

                var responseBytes = Encoding.UTF8.GetBytes(response.ToString());

                await stream.WriteAsync(responseBytes, 0, responseBytes.Length);
                await stream.WriteAsync(response.Body, 0, response.Body.Length);

                tcpClient.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public void AddRoute(string path, Func<HttpRequest, HttpResponse> action)
        {
            throw new NotImplementedException();
        }
    }
}
