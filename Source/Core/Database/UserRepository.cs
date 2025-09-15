using Core.Database.Models;
using Core.Framework;
using Microsoft.EntityFrameworkCore;

namespace Core.Database;

// Interface for User-specific operations
public interface IUserRepository : IRepository<User, int>
{
    Task<User?> GetByEmailAsync(string email);
    Task<List<User>> GetActiveUsersAsync();
}

// Auto-register this repository using the Mercury attribute
[MercuryRepository(typeof(IUserRepository))] // AutoRegister - this class as IUserRepository
public class UserRepository : Repository<User, int, SpireonDbContext>, IUserRepository
{
    public UserRepository(SpireonDbContext context) : base(context)
    {
    }

    // METHOD: Get user by email
    public async Task<User?> GetByEmailAsync(string email)
    {
        return await DbSet.FirstOrDefaultAsync(u => u.Email == email);
    }

    // METHOD: Get only active users
    public async Task<List<User>> GetActiveUsersAsync()
    {
        return await DbSet.Where(u => u.IsActive).ToListAsync();
    }
}
