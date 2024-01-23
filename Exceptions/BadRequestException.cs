namespace washbook_backend.Infrastructure;

public class BadRequestException : Exception
{
    public BadRequestException() : base("Bad request.")
    {
    }

    public BadRequestException(string message) : base(message)
    {
    }

    public BadRequestException(string message, Exception innerException) : base(message, innerException)
    {
    }
}