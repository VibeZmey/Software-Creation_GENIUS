using Microsoft.AspNetCore.Identity;
using WebApi.DTO;
using WebApi.Interfaces.Repositories;
using WebApi.Interfaces.Services;
using WebApi.Persistence.Models;

namespace WebApi.Services;

public class UserService(
    IUserRepository userRepository,
    IJwtService jwtService,
    IRoleRepository roleRepository
    ) : IUserService
{
    public async Task Register(RegisterUserRequest user)
    {
        User newUser = new User()
        {
            Id = Guid.NewGuid(),
            Login = user.Login,
            Email = user.Email,
            Description = user.Description,
            CreatedAt = DateTime.UtcNow,
        };
        var passHash = new PasswordHasher<User>().HashPassword(newUser, user.Password);
        newUser.PasswordHash = passHash;
        
        var role = await roleRepository.GetRoleByName("User");
        if(role is null)
            throw new Exception("Role not found");
        
        newUser.RoleId = role.Id;
        
        await userRepository.AddUser(newUser);
    }

    public async Task<LoginUserResponse?> Login(LoginUserRequest loginUser)
    {
        User? user = await userRepository.GetUserByLogin(loginUser.Login);

        if (user is null) return null;
        
        var result = new PasswordHasher<User>()
            .VerifyHashedPassword(user, user.PasswordHash, loginUser.Password);

        if (result == PasswordVerificationResult.Failed)
            throw new Exception("Unauthorized");

        
        return await jwtService.GenerateJwt(user);
    }

    public async Task<GetUserResponse?> GetUserById(Guid id)
    {
        var user = await userRepository.GetUserById(id);

        GetUserResponse response = new GetUserResponse()
        {
            Id = user.Id,
            Login = user.Login,
            Description = user.Description,
            Email = user.Email,
            IsEditor = user.IsEditor,
            IsArtist = user.IsArtist,
            ImageUrl = user.ImageUrl,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt,
        };
        
        return response;
    }
}