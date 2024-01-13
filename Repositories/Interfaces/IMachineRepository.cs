using washbook_backend.Models;

namespace washbook_backend.Repositories.Interfaces;

public interface IMachineRepository: IRepository<Machine>
{
    public Task<Machine> GetByIdAsync(int id);
}