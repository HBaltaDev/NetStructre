namespace Server.Infrastructure.ExectionHandling.ErrorMessage;

public static class ErrorDefinitions
{
    public static readonly Error UserNotFound =
        new(StatusCodes.NOT_FOUND, "USER_NOT_FOUND");
    
    public static readonly Error SystemError =
        new(StatusCodes.INTERNAL_SERVER_ERROR, "SYSTEM_ERROR");
}