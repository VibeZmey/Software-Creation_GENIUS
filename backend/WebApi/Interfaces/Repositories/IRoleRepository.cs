using WebApi.Persistence.Models;

namespace WebApi.Interfaces.Repositories;

public interface IRoleRepository
{
    Task<Role?> GetRoleByName(string roleName);
    Task<Role?> GetRoleById(Guid roleId);
}