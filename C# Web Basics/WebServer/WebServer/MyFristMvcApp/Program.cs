using WebServer.HTTP;

namespace MyFristMvcApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            HttpServer server = new HttpServer();
            server.Start(80);

            server.AddRoute("/", HomePage);
            server.AddRoute("/login", Login);
            server.AddRoute("/about", About);
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
