using Microsoft.EntityFrameworkCore;
using washbook_backend.Data;
using washbook_backend.Exceptions.Machine;
using washbook_backend.Models;
using washbook_backend.Repositories.Interfaces;

namespace washbook_backend.Repositories.Implementations;

public class MachineRepository : IMachineRepository
{
    private readonly AppDbContext _context;

    public MachineRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Machine>> GetAllAsync()
    {
        return await _context.Machines.ToListAsync();
    }

    public async Task<Machine> GetByIdAsync(int id)
    {
        var machine = await _context.Machines.FindAsync(id);

        if (machine == null)
        {
            // Throw the custom exception
            throw new MachineNotFoundException();
        }

        return machine;
    }

    public async Task AddAsync(Machine entity)
    {
        await _context.Machines.AddAsync(entity);
        // await _context.SaveChangesAsync();
    }

    public async Task Delete(Machine entity)
    {
        _context.Machines.Remove(entity);
        await  _context.SaveChangesAsync();
        // await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Machine entity)
    {
        _context.Machines.Remove(entity);
        // await _context.SaveChangesAsync();
    }
}