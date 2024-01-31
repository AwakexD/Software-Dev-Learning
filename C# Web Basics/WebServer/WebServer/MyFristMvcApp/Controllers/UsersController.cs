using System.Text;
using WebServer.HTTP;
using WebServer.MvcFramework;

namespace MyFristMvcApp.Controllers
{
    public class UsersController : Controller
    {
        public HttpResponse Login(HttpRequest request)
        {
            return this.View("Login.html");
        }
        public HttpResponse Register(HttpRequest request)
        {
            return this.View("Register.html");
        }
    }
}
