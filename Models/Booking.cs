using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace washbook_backend.Models;

public class Booking
{
    [Key] public int Id { get; set; }

    public required DateTime DateTime { get; set; }

    public required int RoomNumber { get; set; }

    [ForeignKey("UserId")] public string? UserId { get; set; }

    public virtual User? User { get; set; }
}