using MyFristMvcApp.Controllers;
using WebServer.HTTP;
using WebServer.MvcFramework;
using HttpMethod = WebServer.HTTP.HttpMethod;

namespace MyFristMvcApp
{
    public class StartUp : IMvcApplication
    {
        public void ConfigureServices()
        {

        }

        public void Configure(List<Route> routes)
        {
            routes.Add(new Route("/", HttpMethod.Get, new HomeController().Index));
            routes.Add(new Route("/about", HttpMethod.Get, new HomeController().About));
            routes.Add(new Route("/users/login", HttpMethod.Get, new UsersController().Login));
            routes.Add(new Route("/users/register", HttpMethod.Get, new UsersController().Register));
        }
    }
}
