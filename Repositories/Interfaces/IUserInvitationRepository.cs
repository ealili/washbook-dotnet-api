using washbook_backend.Models;

namespace washbook_backend.Repositories.Interfaces;

public interface IUserInvitationRepository: IRepository<UserInvitation>
{
    public Task<UserInvitation> GetByIdAsync(int id);
    public Task<UserInvitation> GetByEmailAsync(string email);
}