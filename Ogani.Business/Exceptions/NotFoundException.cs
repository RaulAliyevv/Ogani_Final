using System.Net;

namespace Ogani.Business.Exceptions;

public class NotFoundException : Exception, IBaseException
{
    public NotFoundException(string message = "Not found") : base(message)
    {

    }

    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.Conflict;
}
