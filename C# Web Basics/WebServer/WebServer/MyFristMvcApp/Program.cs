using MyFristMvcApp.Controllers;
using WebServer.HTTP;
using WebServer.MvcFramework;
using HttpMethod = WebServer.HTTP.HttpMethod;

namespace MyFristMvcApp
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            await Host.CreateHostAsync(new StartUp(), 80);
        }
    }
}
