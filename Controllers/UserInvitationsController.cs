using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using washbook_backend.Data;
using washbook_backend.DTOs;
using washbook_backend.Models;
using washbook_backend.Utilities.Helpers;

namespace washbook_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserInvitationsController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly UserManager<User> _userManager;

    public UserInvitationsController(AppDbContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserInvitationDto userInvitationDto)
    {
        var user = await _userManager.FindByEmailAsync(userInvitationDto.Email);

        if (user != null)
        {
            var errorResponse = new ApiResponse<string>(false, "User already exists", null);
            return BadRequest(errorResponse);
        }

        var userInvitation =
            await _context.UserInvitations.FirstOrDefaultAsync(ui => ui.Email == userInvitationDto.Email);

        if (userInvitation != null)
        {
            var errorResponse = new ApiResponse<string>(false, "User is already invited!", null);

            return BadRequest(errorResponse);
        }

        try
        {
            var invitation = new UserInvitation
            {
                Email = userInvitationDto.Email,
                InvitationToken = Guid.NewGuid().ToString()
            };

            await _context.UserInvitations.AddAsync(invitation);
            await _context.SaveChangesAsync();
            return Ok();
        }
        catch (Exception e)
        {
            var errorResponse = new ApiResponse<string>(false, "Failed to invite user!", null);

            return BadRequest(errorResponse);
        }
    }
}