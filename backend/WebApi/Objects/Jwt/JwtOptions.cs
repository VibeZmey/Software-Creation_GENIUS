namespace WebApi.Objects.Jwt;

public class JwtOptions
{
    public string SecretKey { get; set; }
    public int TokenValidityMins { get; set; }
    public int RefreshTokenValidityMins { get; set; }
}