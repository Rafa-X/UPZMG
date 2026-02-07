using Microsoft.EntityFrameworkCore;
using UPZMG.Persistence.Models;

namespace UPZMG.Persistence;

public class DBContext : DbContext
{
    public DBContext(DbContextOptions<DBContext> options) : base(options) { }

    // Minimal set to start with:
    public DbSet<SystemUser> SystemUser => Set<SystemUser>();
    public DbSet<Role> Role => Set<Role>();
    public DbSet<UserRole> UserRole => Set<UserRole>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Map to schema "seguridad"
        modelBuilder.Entity<SystemUser>().ToTable("system_User", "security");
        modelBuilder.Entity<Role>().ToTable("roles", "security");
        modelBuilder.Entity<UserRole>().ToTable("user_roles", "security");

        // Add keys that match your SQL (adjust property names to your exact columns)
        modelBuilder.Entity<SystemUser>().HasKey(x => x.Id);
        modelBuilder.Entity<Role>().HasKey(x => x.Id);
        modelBuilder.Entity<UserRole>().HasKey(x => x.Id);

        // Relationships (adjust FK names as per your script)
        modelBuilder.Entity<UserRole>()
            .HasOne<SystemUser>()
            .WithMany()
            .HasForeignKey(x => x.UserId);

        modelBuilder.Entity<UserRole>()
            .HasOne<Role>()
            .WithMany()
            .HasForeignKey(x => x.RoleId);
    }
}