using washbook_backend.Models;
using washbook_backend.Repositories.Interfaces;

namespace washbook_backend.Repositories.Implementations;

public class UserInvitationRepository: IUserInvitationRepository
{
    public Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserInvitation>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(UserInvitation entity)
    {
        throw new NotImplementedException();
    }

    public Task Delete(UserInvitation entity)
    {
        throw new NotImplementedException();
    }

    public Task<UserInvitation> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}