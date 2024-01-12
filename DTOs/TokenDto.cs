namespace washbook_backend.DTOs;

using System.ComponentModel.DataAnnotations;

#nullable disable
public class TokenDto
{
    [Required] public string Token { get; set; }

    [Required] public string RefreshToken { get; set; }
}