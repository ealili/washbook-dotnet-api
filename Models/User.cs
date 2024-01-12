using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace washbook_backend.Models;

#nullable disable
public class User : IdentityUser
{
    public string FirstName { get; set; }

    public string LastName { get; set; }
    
    public ICollection<Booking> Bookings { get; set; }
}