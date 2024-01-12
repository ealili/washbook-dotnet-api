using washbook_backend.DTOs;
using washbook_backend.Models;

namespace washbook_backend.Services.Interfaces;

public interface IJWTManagerService
{
    public Task<AuthDto> VerifyAndGenerateTokenAsync(TokenDto tokenDto);
    public Task<AuthDto> GenerateJWTTokenAsync(User user, RefreshToken rToken);
}