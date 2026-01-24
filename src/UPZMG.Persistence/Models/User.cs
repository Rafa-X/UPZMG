namespace UPZMG.Persistence.Models;

public class Users
{
    public Guid Id { get; set; }

    // Adjust to your real column name:
    public string User { get; set; } = "";

    // Adjust to your real column name:
    public string PasswordHash { get; set; } = "";

    // Adjust to your real column name:
    public bool Active { get; set; } = true;
}

public class Role
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
}

public class UserRole
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }
}
