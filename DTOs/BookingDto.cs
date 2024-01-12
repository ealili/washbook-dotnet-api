using washbook_backend.DTOs;

public class BookingDto
{
    public int Id { get; set; }
    public DateTime DateTime { get; set; }
    public int RoomNumber { get; set; }

    public UserDto? User { get; set; }
}