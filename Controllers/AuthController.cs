using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using washbook_backend.Data;
using washbook_backend.DTOs;
using washbook_backend.Models;
using washbook_backend.Services.Interfaces;
using washbook_backend.Utilities.Helpers;

namespace washbook_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly IJWTManagerService _jwtManagerService;

    public AuthController(
        UserManager<User> userManager,
        IJWTManagerService jwtManagerService
    )
    {
        _userManager = userManager;
        _jwtManagerService = jwtManagerService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        var userExists = await _userManager.FindByEmailAsync(registerDto.EmailAddress);

        if (userExists != null)
        {
            return BadRequest($"User {registerDto.EmailAddress} already exists.");
        }

        User newUser = new User()
        {
            FirstName = registerDto.FirstName,
            LastName = registerDto.LastName,
            Email = registerDto.EmailAddress,
            UserName = registerDto.Username,
            SecurityStamp = Guid.NewGuid().ToString(),
        };

        var result = await _userManager.CreateAsync(newUser, registerDto.Password);

        if (result.Succeeded)
        {
            switch (registerDto.Role)
            {
                case UserRoles.Manager:
                    await _userManager.AddToRoleAsync(newUser, UserRoles.Manager);
                    break;
                case UserRoles.Student:
                    await _userManager.AddToRoleAsync(newUser, UserRoles.Student);
                    break;
                default:
                    break;
            }

            var userRoles = await _userManager.GetRolesAsync(newUser);

            var response = new
            {
                newUser.FirstName,
                newUser.LastName,
                newUser.Email,
                newUser.UserName,
                Role = userRoles
            };

            return Ok(response);
        }

        return BadRequest($"User could not be created. {result.ToString()}");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var userExists = await _userManager.FindByEmailAsync(loginDto.EmailAddress);

        if (userExists == null || !await _userManager.CheckPasswordAsync(userExists, loginDto.Password))
            return Unauthorized();

        var tokenValue = await _jwtManagerService.GenerateJWTTokenAsync(userExists, null);

        return Ok(tokenValue);
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshToken([FromBody] TokenDto tokenDto)
    {
        var result = await _jwtManagerService.VerifyAndGenerateTokenAsync(tokenDto);
        return Ok(result);
    }
}