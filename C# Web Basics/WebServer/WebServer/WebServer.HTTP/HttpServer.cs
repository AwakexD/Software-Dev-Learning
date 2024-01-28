namespace WebServer.HTTP
{
    public class HttpServer : IHttpServer
    {
        public void Start(int port)
        {
            throw new NotImplementedException();
        }

        public void AddRoute(string path, Func<HttpRequest, HttpResponse> action)
        {
            throw new NotImplementedException();
        }
    }
}
