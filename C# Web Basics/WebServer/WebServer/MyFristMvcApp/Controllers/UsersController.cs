using System.Text;
using WebServer.HTTP;
using WebServer.MvcFramework;

namespace MyFristMvcApp.Controllers
{
    public class UsersController : Controller
    {
        HttpResponse Login(HttpRequest request)
        {
            var responseHtml = "<h1>Login</h1>";
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }

        HttpResponse Register(HttpRequest request)
        {
            var responseHtml = "<h1>Register</h1>";
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }
    }
}
