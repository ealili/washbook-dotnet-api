using System.ComponentModel.DataAnnotations;

namespace washbook_backend.DTOs
{
    public class RegisterDto
    {
        [Required] public string FirstName { get; set; }

        [Required] public string LastName { get; set; }

        [Required] public string EmailAddress { get; set; }

        [Required] public string Username { get; set; }

        [Required] public string Password { get; set; }

        [Required] public string Role { get; set; }
    }
}