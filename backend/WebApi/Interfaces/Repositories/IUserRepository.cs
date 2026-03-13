using WebApi.Persistence.Models;

namespace WebApi.Interfaces.Repositories;

public interface IUserRepository
{
    Task AddUser(User user, CancellationToken ct = default);
    Task<User?> GetUserByLogin(string login, CancellationToken ct = default);
    Task<User?> GetUserById(Guid userId, CancellationToken ct = default);
}