using System.ComponentModel.DataAnnotations;

namespace washbook_backend.DTOs
{
    public class RegisterDto
    {
        [Required] public required string FirstName { get; set; }

        [Required] public required string LastName { get; set; }

        [Required] public required string EmailAddress { get; set; }

        [Required] public required string Username { get; set; }

        [Required] public required string Password { get; set; }

        [Required] public required string Role { get; set; }
    }
}