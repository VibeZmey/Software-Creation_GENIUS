using System.Text.Json.Serialization;

namespace WebApi.Persistence.Models;

public class RefreshToken
{
    public string Token { get; set; }
    public DateTime Expires { get; set; }
    public Guid UserId { get; set; }
    [JsonIgnore]
    public User User { get; set; }
}