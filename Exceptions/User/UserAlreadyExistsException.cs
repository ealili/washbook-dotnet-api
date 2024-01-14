using washbook_backend.Exceptions.UserInvitations;

namespace washbook_backend.Exceptions.User;

public class UserAlreadyExistsException : Exception
{
    public UserAlreadyExistsException() : base("User already exists.")
    {
    }
}