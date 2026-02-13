namespace NetStructre.Infrastructure.ExectionHandling;

public enum StatusCodes
{
    SUCCESS = 200,
    SYSTEM_ERROR = 500,
    BAD_REQUEST = 400,
    UNAUTHORIZED = 401,
    FORBIDDEN = 403,
    NOT_FOUND = 404,
    ALREADY_EXISTS = 409,
    UNPROCESSABLE = 422,
    LOCKED = 423,
    INTERNAL_SERVER_ERROR = 500
}