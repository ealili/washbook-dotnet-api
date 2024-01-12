namespace washbook_backend.DTOs;

using System.ComponentModel.DataAnnotations;

#nullable disable
public class LoginDto
{
    [Required] public string EmailAddress { get; set; }
    [Required] public string Password { get; set; }
}