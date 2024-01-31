using MyFristMvcApp.Controllers;
using WebServer.HTTP;
using HttpMethod = WebServer.HTTP.HttpMethod;

namespace MyFristMvcApp
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            List<Route> routes = new List<Route>();
            routes.Add(new Route("/", HttpMethod.Get, new HomeController().Index));
            routes.Add(new Route("/about", HttpMethod.Get, new HomeController().About));
            routes.Add(new Route("/users/login", HttpMethod.Get, new UsersController().Login));
            routes.Add(new Route("/users/register", HttpMethod.Get, new UsersController().Register));

            HttpServer server = new HttpServer(routes);
            await server.StartAsync(80);

        }
    }
}
