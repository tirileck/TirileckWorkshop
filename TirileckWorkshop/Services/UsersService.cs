using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TirileckWorkshop.Data;
using TirileckWorkshop.Data.Dto;
using TirileckWorkshop.Data.Models;

namespace TirileckWorkshop.Services;

public class UsersService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    
    public UsersService(
        ApplicationDbContext context,
        IMapper mapper
    )
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<UserDto>> GetUsers()
    {
        return _mapper.Map<List<UserDto>>(await _context.Users.ToListAsync());
    }

    public async Task<UserDto> AddUser(AddUserDto dto)
    {
        var addedUser = _mapper.Map<User>(dto);
        // Password to mail
        addedUser.Password = Guid.NewGuid().ToString();
        await _context.AddAsync(addedUser);
        await _context.SaveChangesAsync();
        return _mapper.Map<UserDto>(addedUser);
    }

    public async Task<UserDto> EditUser(UserDto user)
    {
        var storageUser = _context.Users.First(x => x.Id == user.Id);
        storageUser.FirstName = user.FirstName;
        storageUser.LastName = user.LastName;
        storageUser.MiddleName = user.MiddleName;
        storageUser.Position = user.Position;
        storageUser.Email = user.Email;
        storageUser.PhoneNumber = user.PhoneNumber;
        _context.Update(storageUser);
        await _context.SaveChangesAsync();
        return _mapper.Map<UserDto>(storageUser);
    }

    public async Task DeleteUser(long userId)
    {
        var storageUser = _context.Users.First(x => x.Id == userId);
        _context.Remove(storageUser);
        await _context.SaveChangesAsync();
    }
}