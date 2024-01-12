namespace washbook_backend.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable
public class RefreshToken
{
    [Key]
    public int Id { get; set; }
    public string Token { get; set; }
    public string JwtId { get; set; }
    public bool IsRevoked { get; set; }
    public DateTime DateAdded { get; set; }
    public DateTime DateExpired { get; set; }

    public string UserId { get; set; }
    [ForeignKey(nameof(UserId))] // Not necessary
    public User User { get; set; }
}