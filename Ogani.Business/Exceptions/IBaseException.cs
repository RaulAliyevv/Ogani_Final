using System.Net;

namespace Ogani.Business.Exceptions;

public interface IBaseException
{
    public HttpStatusCode StatusCode { get; set; }
}
