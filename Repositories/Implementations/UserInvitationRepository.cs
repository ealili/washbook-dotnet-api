using Microsoft.EntityFrameworkCore;
using washbook_backend.Data;
using washbook_backend.Models;
using washbook_backend.Repositories.Interfaces;

namespace washbook_backend.Repositories.Implementations;

public class UserInvitationRepository : IUserInvitationRepository
{
    private readonly AppDbContext _context;

    public UserInvitationRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public Task<IEnumerable<UserInvitation>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(UserInvitation entity)
    {
        await _context.UserInvitations.AddAsync(entity);
    }

    public Task Delete(UserInvitation entity)
    {
        throw new NotImplementedException();
    }

    public Task<UserInvitation> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<UserInvitation> GetByEmailAsync(string email)
    {
        return  await _context.UserInvitations.FirstOrDefaultAsync(ui => ui.Email == email);
    }
}