using washbook_backend.Models;

namespace washbook_backend.Services.Interfaces;

public interface IMachineService: IService<Machine>
{
    Task<Machine> GetByIdAsync(int id);
}