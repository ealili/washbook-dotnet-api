using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using washbook_backend.DTOs;
using washbook_backend.Models;
using washbook_backend.Services.Interfaces;
using washbook_backend.Utilities.Helpers;

namespace washbook_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserInvitationsController : ControllerBase
{
    private readonly IUserInvitationService _userInvitationService;

    public UserInvitationsController(IUserInvitationService userInvitationService, UserManager<User> userManager)
    {
        _userInvitationService = userInvitationService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserInvitationDto userInvitationDto)
    {
        try
        {
            var invitation = new UserInvitation
            {
                Email = userInvitationDto.Email,
                InvitationToken = Guid.NewGuid().ToString()
            };

            await _userInvitationService.AddAsync(invitation);
            
            var response = new ApiResponse<UserInvitation>(true, "Data created successfully", invitation);

            return Ok(response);
        }
        catch (Exception exception)
        {
            var errorResponse = new ApiResponse<string>(false,  exception.Message, null);

            return BadRequest(errorResponse);
        }
    }
}