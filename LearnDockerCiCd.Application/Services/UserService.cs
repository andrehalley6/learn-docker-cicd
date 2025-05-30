using System;
using LearnDockerCiCd.Application.DTO;
using LearnDockerCiCd.Application.Interfaces;
using LearnDockerCiCd.Domain.Entities;
using LearnDockerCiCd.Infrastructure.Interfaces;

namespace LearnDockerCiCd.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync(CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllUsersAsync(cancellationToken);
        return users.Select(u => new UserDto
        {
            ID = u.ID,
            Name = u.Name,
            Email = u.Email
        });
    }

    public async Task<UserDto?> GetUserAsync(int id, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserAsync(id, cancellationToken);
        if (user == null) return null;

        return new UserDto
        {
            ID = user.ID,
            Name = user.Name,
            Email = user.Email
        };
    }

    public async Task<UserDto> CreateUserAsync(CreateUserDto createUserDto, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Name = createUserDto.Name,
            Email = createUserDto.Email
        };

        var createdUser = await _userRepository.CreateUserAsync(user, cancellationToken);
        
        return new UserDto
        {
            Name = createdUser.Name,
            Email = createdUser.Email
        };
    }
}