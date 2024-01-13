using washbook_backend.Models;
using washbook_backend.Repositories.Interfaces;
using washbook_backend.Services.Interfaces;

namespace washbook_backend.Services.Implementations;

public class MachineService(IMachineRepository machineRepository) : IMachineService
{
    public async Task<IEnumerable<Machine>> GetAllAsync()
    {
        return await machineRepository.GetAllAsync();
    }

    public async Task AddAsync(Machine entity)
    {
        await machineRepository.AddAsync(entity);
        await machineRepository.SaveChangesAsync();
    }

    public async Task DeleteAsync(Machine entity)
    {
        await machineRepository.Delete(entity);
        await machineRepository.SaveChangesAsync();
    }

    public async Task<Machine> GetByIdAsync(int id)
    {
        return await machineRepository.GetByIdAsync(id);
    }
}