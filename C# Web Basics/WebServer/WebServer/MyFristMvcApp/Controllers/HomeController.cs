using System.Text;
using WebServer.HTTP;
using WebServer.MvcFramework;

namespace MyFristMvcApp.Controllers
{
    public class HomeController : Controller
    {
        HttpResponse Index(HttpRequest request)
        {
            var responseHtml = "<h1>Welcome! HomePage</h1>" + request.Headers.FirstOrDefault(x => x.Name == "User-Agent")?.Value;
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }

        HttpResponse About(HttpRequest request)
        {
            var responseHtml = "<h1>About ....</h1>";
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }
    }
}
