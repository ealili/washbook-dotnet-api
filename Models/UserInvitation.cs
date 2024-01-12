using System.ComponentModel.DataAnnotations;

namespace washbook_backend.Models;

public class UserInvitation
{
    [Key] public int Id { get; set; }

    public string InvitationToken { get; set; }

    public string Email { get; set; }
}