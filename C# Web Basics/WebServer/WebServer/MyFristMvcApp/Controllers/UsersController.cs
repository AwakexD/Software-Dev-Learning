using System.Text;
using WebServer.HTTP;
using WebServer.MvcFramework;

namespace MyFristMvcApp.Controllers
{
    public class UsersController : Controller
    {
        HttpResponse Login(HttpRequest request)
        {
            return this.View("Views/Users/Login.html");
        }
        HttpResponse Register(HttpRequest request)
        {
            return this.View("Views/Users/Register.html");
        }
    }
}
