// UserProfile.cs

using AutoMapper;
using washbook_backend.DTOs;
using washbook_backend.Models;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>();
    }
}