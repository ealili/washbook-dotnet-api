using washbook_backend.Models;

namespace washbook_backend.Services.Interfaces;

public interface IBookingService: IService<Booking>
{
    Task<Booking> GetByIdAsync(int id);
}