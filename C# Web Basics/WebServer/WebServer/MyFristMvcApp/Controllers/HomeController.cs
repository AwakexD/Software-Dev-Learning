using System.Text;
using WebServer.HTTP;
using WebServer.MvcFramework;

namespace MyFristMvcApp.Controllers
{
    public class HomeController : Controller
    {
        HttpResponse Index(HttpRequest request)
        {
            return this.View("Views/Home/Index.html");
        }

        HttpResponse About(HttpRequest request)
        {
            return this.View("Views/Home/About.html");
        }
    }
}
