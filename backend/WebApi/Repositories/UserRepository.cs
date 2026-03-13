using Microsoft.EntityFrameworkCore;
using WebApi.DTO;
using WebApi.Interfaces;
using WebApi.Interfaces.Repositories;
using WebApi.Persistence.Models;

namespace WebApi.Repositories;

public class UserRepository(IAppDbContext context, ILogger<UserRepository> logger) 
    : IUserRepository
{
    public async Task AddUser(User user, 
        CancellationToken cancellationToken = default)
    {
        await context.Users.AddAsync(user, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<User?> GetUserByLogin(string login, CancellationToken ct = default)
    {
        User? user = await context.Users.FirstOrDefaultAsync(user => user.Login == login, ct);
        return user;
    }

    public async Task<User?> GetUserById(Guid userId, CancellationToken ct = default)
    {
        User? user = await context.Users.FirstOrDefaultAsync(user => user.Id == userId, ct);
        return user;
    }
}