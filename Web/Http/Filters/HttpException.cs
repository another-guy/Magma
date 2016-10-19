using System;
using System.Net;

namespace Magma.Web.Http.Filters
{
    public class HttpException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; private set; }

        public HttpException(HttpStatusCode httpStatusCode, string message = "")
            : base(message)
        {
            HttpStatusCode = httpStatusCode;
        }
    }
}
