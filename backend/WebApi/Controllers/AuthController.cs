using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTO;
using WebApi.Interfaces.Repositories;
using WebApi.Interfaces.Services;
using WebApi.Objects.Enum;
using WebApi.Persistence.Models;

namespace WebApi.Controllers;

[ApiController]
[AllowAnonymous]
[Route("auth")]
public class AuthController(
    IUserService userService,
    IJwtService jwtService) 
    : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserRequest user)
    {
        var res = await userService.Login(user);

        return res is null ? Unauthorized() : Ok(res);
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserRequest user)
    {
        await userService.Register(user);
        return Ok();
    }
    
    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh(RefreshRequest request)
    {
        if(string.IsNullOrWhiteSpace(request.Token))
            return BadRequest("Invalid token");
        
        var res = await jwtService.ValidateRefreshJwt(request.Token);
        
        return res is null ? Unauthorized() : Ok(res);
    }
}