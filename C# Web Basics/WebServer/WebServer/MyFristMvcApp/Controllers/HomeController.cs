using System.Text;
using WebServer.HTTP;
using WebServer.MvcFramework;

namespace MyFristMvcApp.Controllers
{
    public class HomeController : Controller
    {
        public HttpResponse Index(HttpRequest request)
        {
            return this.View("Index.html");
        }

        public HttpResponse About(HttpRequest request)
        {
            return this.View("About.html");
        }
    }
}
