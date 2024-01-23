using Microsoft.AspNetCore.Identity;

namespace washbook_backend.Models;

public class User : IdentityUser
{
    public required string FirstName { get; set; }

    public required string LastName { get; set; }
    
    public ICollection<Booking>? Bookings { get; set; }
}