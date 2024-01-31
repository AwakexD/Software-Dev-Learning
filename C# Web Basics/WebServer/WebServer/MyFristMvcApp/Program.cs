using WebServer.HTTP;

namespace MyFristMvcApp
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            HttpServer server = new HttpServer();
            //server.AddRoute("/", HomePage);
            //server.AddRoute("/login", Login);
            //server.AddRoute("/about", About);

            await server.StartAsync(80);
        }
    }
}
