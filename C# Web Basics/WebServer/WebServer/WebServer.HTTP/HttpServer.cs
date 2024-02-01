using System.Net;
using System.Net.Sockets;
using System.Text;

namespace WebServer.HTTP
{
    public class HttpServer : IHttpServer
    {
        private List<Route> routeTable;

        public HttpServer(List<Route> table)
        {
            this.routeTable = table;
        }

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
                HttpResponse response;
                var route = this.routeTable.FirstOrDefault(
                    x => string.Compare(x.Path, request.Path, true) == 0 && x.Method == request.Method);
                
                if (route != null)
                {
                    response = route.Action(request);
                }
                else
                {
                    // Not Found 404
                    response = new HttpResponse("text/html", new byte[0], HttpStatusCode.NotFound);
                }

                response.Headers.Add(new Header("X-Server", "MyWebServer 1.1"));

                var sessionCookie = request.Cookies.FirstOrDefault(x => x.Name == HttpConstants.SessionCookieName);
                if (sessionCookie != null)
                {
                    var responseSessionCookie = new ResponseCookie(sessionCookie.Name, sessionCookie.Value);
                    responseSessionCookie.Path = "/";
                    response.Cookies.Add(responseSessionCookie);
                }

                var responseHeaderBytes = Encoding.UTF8.GetBytes(response.ToString());
                await stream.WriteAsync(responseHeaderBytes, 0, responseHeaderBytes.Length);

                if (response.Body != null)
                {
                    await stream.WriteAsync(response.Body, 0, response.Body.Length);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            tcpClient.Close();
        }


        public void AddRoute(string path, Func<HttpRequest, HttpResponse> action)
        {
            throw new NotImplementedException();
        }
    }
}
