using System.Text;
using WebServer.HTTP;

namespace WebServer.MvcFramework
{
    public abstract class Controller
    {
        public HttpResponse View(string viewPath)
        {
            var responseHtml = File.ReadAllText("Views/Users/Login.html");
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }
    }
}
