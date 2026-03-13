using Microsoft.EntityFrameworkCore;
using WebApi.Interfaces;
using WebApi.Interfaces.Repositories;
using WebApi.Persistence.Models;

namespace WebApi.Repositories;

public class RoleRepository(IAppDbContext context) 
    : IRoleRepository
{
    public async Task<Role?> GetRoleByName(string roleName)
    {
        Role? role = await context.Roles.FirstOrDefaultAsync(r => r.Name == roleName);
        if(role is null)
            throw new Exception($"Role {roleName} not found");
        
        return role;
    }

    public async Task<Role?> GetRoleById(Guid roleId)
    {
        Role? role = await context.Roles.FirstOrDefaultAsync(r => r.Id == roleId);
        if(role is null)
            throw new Exception($"Role {roleId} not found");
        
        return role;
    }
}