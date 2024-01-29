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

        static HttpResponse HomePage(HttpRequest request)
        {
            throw new NotImplementedException();
        }
        static HttpResponse Login(HttpRequest request)
        {
            throw new NotImplementedException();
        }
        static HttpResponse About(HttpRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
