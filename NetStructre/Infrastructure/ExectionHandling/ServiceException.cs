namespace NetStructre.Infrastructure.ExectionHandling;

public class ServiceException : Exception
{
    public StatusCodes StatusCode { get; set; }
    public string Description { get; set; }

    public ServiceException(StatusCodes statusCode, string description, string? errorMessage = null) : base(errorMessage ?? string.Empty)
    {
        StatusCode = statusCode;
        Description = description;
    }
}