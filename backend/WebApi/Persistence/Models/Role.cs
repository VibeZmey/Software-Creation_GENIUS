using System.Text.Json.Serialization;

namespace WebApi.Persistence.Models;

public class Role
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    [JsonIgnore]
    public List<User> Users { get; set; }
}