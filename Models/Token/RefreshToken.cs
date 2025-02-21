using Microsoft.EntityFrameworkCore;
using pruebaAPI.Models;

[PrimaryKey(nameof(Id))]
public class RefreshToken
{
    public Guid Id = Guid.NewGuid();
    public required string Token { get; set; }
    public DateTime Expires { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Revoked { get; set; }

    public bool IsActive => Revoked == null && DateTime.UtcNow <= Expires;
    public Guid UserId { get; set; }

    public User? User { get; set; }
}
