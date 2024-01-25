using System.Net;
using System.Text;
using System.Net.Sockets;

namespace BasicHttpClient
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            const string NewLine = "\r\n";
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 12345);
            tcpListener.Start();

            while (true)
            {
                var client = tcpListener.AcceptTcpClient();
                using (var stream = client.GetStream())
                {
                    byte[] buffer = new byte[10000000];
                    var length = stream.Read(buffer, 0, buffer.Length);

                    string requestString = Encoding.UTF8.GetString(buffer);

                    string responseHtml = $"<h1>Hello from MyServer {DateTime.Now}</h1>" +
                                          "<form method=post><input type=text id=username name=username><br>" +
                                          "<input type=text id=password name=password><br>" +
                                          "<input type=submit value=Submit></form>";
                    
                    string response = "HTTP/1.1 200 OK" + NewLine + "Server: MyServer2024" + NewLine +
                                      "Content-Type: text/html" + NewLine +
                                      //"Location : https://youtube.com" + NewLine +
                                      "Content-Length: " + responseHtml.Length + NewLine +
                                      NewLine + responseHtml + NewLine;
                    
                    byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                    stream.Write(responseBytes);


                    Console.WriteLine(requestString);
                    Console.WriteLine(new string('-', 30));
                }
            }
        }

        public static async Task ReadData()
        {
            Console.OutputEncoding = Encoding.UTF8;
            string url = "https://softuni.bg";

            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);

            Console.WriteLine($"Status Code : {response.StatusCode}");
            Console.WriteLine("Headers: ");
            Console.WriteLine(string.Join("\n", response.Headers.Select(x => x.Key + " : " + x.Value.FirstOrDefault())));
        }
    }
}
