namespace WebServer.HTTP
{
    public class HttpRequest
    {
        public HttpRequest(string request)
        {
            string[] lines = request.Split(new string[] {HttpConstants.NewLine}, StringSplitOptions.None);

            // GET /page HTTP/1.1
            string headerLine = lines[0];
            string[] headerLineParts = headerLine.Split(' ');
            this.Method = headerLineParts[0];
            this.Path = headerLineParts[1];

            //ToDo : repsonse destructing
        }
        public string Path { get; set; }

        public string Method { get; set; }

        public List<Header> Headers { get; set; }

        public List<Cookie> Cookies { get; set; }
    }

}
