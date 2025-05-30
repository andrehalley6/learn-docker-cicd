using LearnDockerCiCd.Application.DTO;
using LearnDockerCiCd.Domain.Entities;

namespace LearnDockerCiCd.Application.Interfaces;

public interface IUserService
{
    /// <summary>
    /// Retrieves all users asynchronously.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>List of users</returns>
    Task<IEnumerable<UserDto>> GetAllUsersAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves a user by their ID asynchronously.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>UserDto or null</returns>
    Task<UserDto?> GetUserAsync(int id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Creates a new user asynchronously.
    /// </summary>
    /// <param name="createUserDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>UserDto</returns>
    Task<UserDto> CreateUserAsync(CreateUserDto createUserDto, CancellationToken cancellationToken);
}