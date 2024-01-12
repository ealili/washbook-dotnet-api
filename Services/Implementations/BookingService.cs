using washbook_backend.Models;
using washbook_backend.Repositories.Interfaces;
using washbook_backend.Services.Interfaces;

namespace washbook_backend.Services.Implementations;

public class BookingService(IBookingRepository bookingRepository) : IBookingService
{
    public async Task<IEnumerable<Booking>> GetAllAsync()
    {
        return await bookingRepository.GetAllAsync();
    }

    public Task<Booking> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Booking entity)
    {
        await bookingRepository.AddAsync(entity);
        
    }
}