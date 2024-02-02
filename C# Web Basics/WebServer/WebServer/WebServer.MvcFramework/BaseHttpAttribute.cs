using WebServer.HTTP;
using System;

namespace SUS.MvcFramework
{
    public abstract class BaseHttpAttribute : Attribute
    {
        public string Url { get; set; }

        public abstract WebServer.HTTP.HttpMethod Method { get; }
    }
}
