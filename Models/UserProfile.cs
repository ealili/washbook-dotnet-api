using AutoMapper;
using washbook_backend.DTOs;

namespace washbook_backend.Models;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>();
    }
}