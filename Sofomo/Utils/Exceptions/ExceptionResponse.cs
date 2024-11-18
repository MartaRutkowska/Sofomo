using System.Net;

namespace Sofomo.Utils.Exceptions
{
    public record ExceptionResponse(HttpStatusCode StatusCode, string Description);
}
