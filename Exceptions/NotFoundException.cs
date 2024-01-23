namespace washbook_backend.Infrastructure;

public class NotFoundException : Exception
{
    public NotFoundException() : base("Requested resource not found.")
    {
    }

    public NotFoundException(string message) : base(message)
    {
    }
}