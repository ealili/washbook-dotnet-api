using Microsoft.EntityFrameworkCore;
using washbook_backend.Data;
using washbook_backend.Models;
using washbook_backend.Repositories.Interfaces;

namespace washbook_backend.Repositories.Implementations;

public class BookingRepository : IBookingRepository
{
    private readonly AppDbContext _context;

    public BookingRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Booking>> GetAllAsync()
    {
        var bookings = await _context.Bookings
            .Include(b => b.User)
            .ToListAsync();

        // Project the results into a new shape
        var result = bookings.Select(b => new Booking
        {
            Id = b.Id,
            DateTime = b.DateTime,
            RoomNumber = b.RoomNumber,
            User = new User
            {
                Id = b.User.Id,
                UserName = b.User.UserName,
                FirstName = b.User.FirstName,
                LastName = b.User.LastName,
                Email = b.User.Email
                // Include other properties you want
            }
        });
        return result;
    }

    public Task<Booking> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Booking entity)
    {
        await _context.Bookings.AddAsync(entity);
        await _context.SaveChangesAsync();
    }
}