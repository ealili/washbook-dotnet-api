using System.Collections;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using washbook_backend.Data;
using washbook_backend.DTOs;
using washbook_backend.Models;
using washbook_backend.Repositories.Interfaces;

namespace washbook_backend.Repositories.Implementations;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public UserRepository(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        var users = await _context.Users
            .Include(u => u.Bookings)
            .ToListAsync();

        return users;

        // var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);
        //
        //
        // return userDtos;
    }

    public async Task<User> GetByIdAsync(string id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return null;
        }

        return user;
    }

    public Task AddAsync(User entity)
    {
        throw new NotImplementedException();
    }
}