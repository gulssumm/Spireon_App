using Core.Database.Models;

namespace Core.Database.Models;

// User Entity - Inherites from EntityBase
public class User : EntityBase<int>
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }
    public bool IsActive { get; set; } = true;
}
