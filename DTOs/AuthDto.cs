using System.ComponentModel.DataAnnotations;

namespace washbook_backend.DTOs
{
    public class AuthDto
    {
        [Required] public string Token { get; set; }

        [Required] public string RefreshToken { get; set; }

        public DateTime ExpiresAt { get; set; }
    }
}