using Microsoft.AspNetCore.Identity;
using washbook_backend.Models;

namespace washbook_backend.Services.Interfaces;

public interface IUserService : IService<User>
{
    public Task<IEnumerable<string>> GetAllUserRolesAsync(User user);
}