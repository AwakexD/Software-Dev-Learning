namespace WebServer.HTTP
{
    public class Cookie
    {
        //sid=ja63ahjdsa1
        public Cookie(string cookieLine)
        {
            var cookieParts = cookieLine.Split(new char[] { '=' }, 2);
            this.Name = cookieParts[0];
            this.Value = cookieParts[1];
        }
        public string Name { get; set; }

        public string Value { get; set; }

        public override string ToString()
        {
            return $"{Name}={Value}";
        }
    }
}
