using WebApi.DTO;
using WebApi.Persistence.Models;

namespace WebApi.Interfaces.Services;

public interface IJwtService
{
    Task<LoginUserResponse> GenerateJwt(User user);
    Task<LoginUserResponse?> ValidateRefreshJwt(string token);
}