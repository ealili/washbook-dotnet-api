using washbook_backend.Models;
using washbook_backend.Services.Interfaces;

namespace washbook_backend.Services.Implementations;

public class UserInvitationService: IUserInvitationService
{
    public Task<IEnumerable<UserInvitation>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(UserInvitation entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(UserInvitation entity)
    {
        throw new NotImplementedException();
    }
}