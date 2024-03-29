﻿using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace WebServerWithCookies
{
    public class Program
    {
        const string NewLine = "\r\n";
        static Dictionary<string, int> SessionStorage = new Dictionary<string, int>();

        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 80);
            tcpListener.Start();

            while (true)
            {
                var client = tcpListener.AcceptTcpClient();
                ProcessClientAsync(client);
            }
        }

        public static async Task ProcessClientAsync(TcpClient client)
        {
            using (var stream = client.GetStream())
            {
                byte[] buffer = new byte[1000000];
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                var lenght = await stream.ReadAsync(buffer, 0, buffer.Length);
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

                string requestString =
                    Encoding.UTF8.GetString(buffer, 0, lenght);
                Console.WriteLine(requestString);

                var sid = Guid.NewGuid().ToString();
                var match = Regex.Match(requestString, @"sid=[^\n]*\r\n");
                if (match.Success)
                {
                    sid = match.Value.Substring(4);
                }

                if (!SessionStorage.ContainsKey(sid))
                {
                    SessionStorage.Add(sid, 0);
                }

                SessionStorage[sid]++;

                Console.WriteLine(sid);

                string html = $"<h1>Hello from TestServer {DateTime.Now} for the {SessionStorage[sid]} time</h1>" +
                    $"<form action= method=post><input name=username /><input name=password />" +
                    $"<input type=submit /></form>" + DateTime.Now;

                string response = "HTTP/1.1 200 OK" + NewLine +
                    "Server: TestServer2024" + NewLine +
                    // "Location: https://www.youtube.com" + NewLine +
                    "Content-Type: text/html; charset=utf-8" + NewLine +
                    "X-Server-Version: 1.0" + NewLine +
                    $"Set-Cookie: sid={sid}; HttpOnly; Max-Age=" + (3 * 24 * 60 * 60) + NewLine +
                    // "Content-Disposition: attachment; filename={filename}" + NewLine +
                    "Content-Lenght: " + html.Length + NewLine +
                    NewLine +
                    html + NewLine;

                byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                await stream.WriteAsync(responseBytes);
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

                Console.WriteLine(new string('=', 70));
            }
        }

        public static async Task ReadData()
        {
            string url = "https://softuni.bg/courses/csharp-web-basics";
            HttpClient httpClient = new HttpClient();

            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            var response = await httpClient.GetAsync(url);

            Console.WriteLine(response.StatusCode);
            Console.WriteLine(string.Join(Environment.NewLine,
                response.Headers.Select(x => x.Key + ": " + x.Value.First())));

            // var html = await httpClient.GetStringAsync(url);
            // Console.WriteLine(html);
        }
    }
}
