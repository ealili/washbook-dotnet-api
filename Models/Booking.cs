using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace washbook_backend.Models;

public class Booking
{
    [Key] public int Id { get; set; }

    public DateTime DateTime { get; set; }

    public int RoomNumber { get; set; }

    [ForeignKey("UserId")] public string UserId { get; set; }

    public virtual User User { get; set; }
}