using LearnDockerCiCd.Domain.Entities;
using LearnDockerCiCd.Infrastructure.Interfaces;
using LearnDockerCiCd.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LearnDockerCiCd.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    
    public UserRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<User>> GetAllUsersAsync(CancellationToken cancellationToken)
    {
        // Implementation to retrieve all users from the database
        return await _context.Users.ToListAsync(cancellationToken);
    }

    public async Task<User?> GetUserAsync(int id, CancellationToken cancellationToken)
    {
        // Implementation to retrieve a user by ID from the database
        return await _context.Users.FirstOrDefaultAsync(u => u.ID == id, cancellationToken);
    }

    public async Task<User> CreateUserAsync(User user, CancellationToken cancellationToken)
    {
        // Implementation to create a new user in the database
        _context.Users.Add(user);
        await _context.SaveChangesAsync(cancellationToken);
        return user;
    }
}