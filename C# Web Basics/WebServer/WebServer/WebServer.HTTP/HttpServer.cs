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
            using NetworkStream stream = tcpClient.GetStream();

            int position = 0;
            byte[] buffer = new byte[4096];
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
            string requestAsString = Encoding.UTF8.GetString(data.ToArray());

            Console.WriteLine(requestAsString);

        }

        public void AddRoute(string path, Func<HttpRequest, HttpResponse> action)
        {
            throw new NotImplementedException();
        }
    }
}
