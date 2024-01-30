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
                                  $"\nHeaders Count: {request.Headers.Count} " +
                                  $"\nCookies:\n{string.Join("\n", request.Cookies.Select(x => x))}\n");

                // Response
                string response = $"<h1>Welcome {DateTime.UtcNow}</h1>";
                byte[] responseBodyBytes = Encoding.UTF8.GetBytes(response);

                string responseHttp = $"HTTP/1.1 200 OK" + HttpConstants.NewLine
                                                         + "Server: WebServer 1.0" + HttpConstants.NewLine
                                                         + "Content-Type: text/html" + HttpConstants.NewLine
                                                         + $"Content-Length: {responseBodyBytes.Length}" + HttpConstants.NewLine
                                                         + HttpConstants.NewLine;
                byte[] responseHeadersBytes = Encoding.UTF8.GetBytes(responseHttp);

                await stream.WriteAsync(responseHeadersBytes, 0, responseHeadersBytes.Length);
                await stream.WriteAsync(responseBodyBytes, 0, responseBodyBytes.Length);

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
