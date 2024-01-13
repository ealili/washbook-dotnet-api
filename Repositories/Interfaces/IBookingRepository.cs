using washbook_backend.Models;

namespace washbook_backend.Repositories.Interfaces;

public interface IBookingRepository: IRepository<Booking>
{
    public Task<Booking> GetByIdAsync(int id);
}