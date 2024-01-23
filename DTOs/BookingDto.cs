using washbook_backend.DTOs;

public class BookingDto
{
    public int Id { get; set; }
    public required DateTime DateTime { get; set; }
    public required int RoomNumber { get; set; }

    public UserDto User { get; set; }
}