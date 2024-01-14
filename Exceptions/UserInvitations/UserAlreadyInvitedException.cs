namespace washbook_backend.Exceptions.UserInvitations;

public class UserAlreadyInvitedException: Exception
{
    public UserAlreadyInvitedException() : base("User is already been invited.")
    {
    }
}