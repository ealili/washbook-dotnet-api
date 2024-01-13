using Microsoft.AspNetCore.Identity;
using washbook_backend.Models;
using washbook_backend.Repositories.Interfaces;
using washbook_backend.Services.Interfaces;

namespace washbook_backend.Services.Implementations;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly UserManager<User> _userManager;

    public UserService(IUserRepository userRepository, UserManager<User> userManager)
    {
        _userRepository = userRepository;
        _userManager = userManager;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _userRepository.GetAllAsync();
    }

    public async Task<User> GetByIdAsync(string id)
    {
        return await _userRepository.GetByIdAsync(id);
    }

    public Task AddAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<string>> GetAllUserRolesAsync(User user)
    {
        return await _userManager.GetRolesAsync(user);
    }
}