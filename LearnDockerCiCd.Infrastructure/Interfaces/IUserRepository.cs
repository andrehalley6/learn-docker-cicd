using LearnDockerCiCd.Domain.Entities;

namespace LearnDockerCiCd.Infrastructure.Interfaces;

public interface IUserRepository
{
    /// <summary>
    /// Retrieves all users asynchronously.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>List of users</returns>
    Task<IEnumerable<User>> GetAllUsersAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves a user by their ID asynchronously.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>User or null</returns>
    Task<User?> GetUserAsync(int id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Creates a new user asynchronously.
    /// </summary>
    /// <param name="user"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>User</returns>
    Task<User> CreateUserAsync(User user, CancellationToken cancellationToken);
}