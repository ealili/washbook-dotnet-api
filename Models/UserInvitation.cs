using System.ComponentModel.DataAnnotations;

namespace washbook_backend.Models;

public class UserInvitation
{
    [Key] public int Id { get; set; }

    public required string InvitationToken { get; set; }

    public required string Email { get; set; }
}