namespace WebApi.DTO;

public class RegisterUserRequest
{
    public string Login { get; set; }
    public string Password { get; set; }
    public string? Description { get; set; }
    public string? Email { get; set; }
}