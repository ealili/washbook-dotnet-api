using Microsoft.AspNetCore.Identity;
using washbook_backend.Exceptions.User;
using washbook_backend.Exceptions.UserInvitations;
using washbook_backend.Models;
using washbook_backend.Repositories.Interfaces;
using washbook_backend.Services.Interfaces;

namespace washbook_backend.Services.Implementations;

public class UserInvitationService: IUserInvitationService
{
    private readonly IUserInvitationRepository _userInvitationRepository;
    private readonly UserManager<User> _userManager;

    public UserInvitationService(IUserInvitationRepository userInvitationRepository, UserManager<User> userManager)
    {
        _userInvitationRepository = userInvitationRepository;
        _userManager = userManager;
    }
    
    public Task<IEnumerable<UserInvitation>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(UserInvitation entity)
    {
        var user = await _userManager.FindByEmailAsync(entity.Email);
        
        if (user != null)
        {
            throw new UserAlreadyExistsException();
            // var errorResponse = new ApiResponse<string>(false, "User already exists", null);
            // return BadRequest(errorResponse);
        }
        
        var userInvitation = await _userInvitationRepository.GetByEmailAsync(entity.Email);
        
        // await _context.UserInvitations.FirstOrDefaultAsync(ui => ui.Email == userInvitationDto.Email);
        
        if (userInvitation != null)
        {
            throw new UserAlreadyInvitedException();
        }

        await _userInvitationRepository.AddAsync(entity);
        await _userInvitationRepository.SaveChangesAsync();
        // await _context.UserInvitations.AddAsync(invitation);
        // await _context.SaveChangesAsync();



    }

    public Task DeleteAsync(UserInvitation entity)
    {
        throw new NotImplementedException();
    }
}