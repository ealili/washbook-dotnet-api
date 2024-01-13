using washbook_backend.DTOs;
using Microsoft.AspNetCore.Mvc;
using washbook_backend.Services.Interfaces;
using washbook_backend.Utilities.Helpers;

namespace washbook_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    // [Authorize(Roles = UserRoles.Manager)]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAllAsync();
        var userDtos = new List<UserDto>();

        foreach (var user in users)
        {
            var roles = await _userService.GetAllUserRolesAsync(user);

            var userDto = new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.UserName,
                Roles = roles.ToList()
            };

            userDtos.Add(userDto);
        }

        var response = new ApiResponse<IEnumerable<UserDto>>(true, "Data retrieved successfully", userDtos);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var user = await _userService.GetByIdAsync(id);
        var roles = await _userService.GetAllUserRolesAsync(user);

        var userDto = new UserDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            UserName = user.UserName,
            Roles = roles.ToList()
        };

        var response = new ApiResponse<UserDto>(true, "Data retrieved successfully", userDto);

        return Ok(response);
    }

    [HttpGet("test")]
    public string Test()
    {
        return "TEST";
    }
}