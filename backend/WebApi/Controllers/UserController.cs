using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTO;
using WebApi.Interfaces.Services;
using WebApi.Persistence.Models;

namespace WebApi.Controllers;

[ApiController]
[Authorize(Roles = "Admin, User")]
[Route("user")]
public class UserController(
    IUserService userService) 
    : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<GetUserResponse>> GetMe()
    {
        var userId = User.FindFirst("userId").Value;
        
        var user = await userService.GetUserById(Guid.Parse(userId));
        if (user == null)
            return NotFound();
        
        return user;
    }
    
    [HttpPatch]
    public async Task<ActionResult<GetUserResponse>> PatchMe()
    {
        var userId = User.FindFirst("userId").Value;
        
        var user = await userService.GetUserById(Guid.Parse(userId));
        if (user == null)
            return NotFound();
        
        return user;
    }
}