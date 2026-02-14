using Server.Infrastructure.ExectionHandling;
using Server.Infrastructure.ExectionHandling.ErrorMessage;
using Server.Infrastructure.ExectionHandling.Localization;

namespace Infrastructure.ExceptionHandling;

public class ServiceException(Error error) : Exception
{ 
     public StatusCodes StatusCode { get; } = error.StatusCode;
     public string Description { get; } = error.Description;
} 