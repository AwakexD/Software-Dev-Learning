using System.Text;

namespace WebServer.HTTP
{
    public class HttpResponse
    {
        public HttpResponse(string contentType, byte[] body, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            if (body == null)
            {
                throw new AbandonedMutexException(nameof(body));
            }

            this.Body = body;
            this.StatusCode = statusCode;
            this.Headers = new List<Header>
            {
                {new Header("Content-Type", contentType)},
                {new Header("Content-Length", body.Length.ToString())},
            };
            this.Cookies = new List<Cookie>();

        }

        public HttpStatusCode StatusCode { get; set; }

        public ICollection<Header> Headers { get; set; }

        public ICollection<Cookie> Cookies { get; set; }

        public byte[] Body { get; set; }

        public override string ToString()
        {
            StringBuilder responseBuilder = new StringBuilder();
            responseBuilder.Append($"HTTP/1.1 {(int)StatusCode} {StatusCode}" + HttpConstants.NewLine);
            
            foreach (var header in Headers)
            {
                responseBuilder.Append(header.ToString() + HttpConstants.NewLine);
            }

            foreach (var cookie in Cookies)
            {
                responseBuilder.Append("Set-Cookie: " + cookie.ToString() + HttpConstants.NewLine);
            }

            responseBuilder.AppendLine(HttpConstants.NewLine);

            return responseBuilder.ToString();
        }
    }
}
