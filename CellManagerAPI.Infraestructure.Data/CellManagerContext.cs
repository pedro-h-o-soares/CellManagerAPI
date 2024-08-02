using CellManagerAPI.Domain.Models;
using CellManagerAPI.Infraestructure.Data.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CellManagerAPI.Infraestructure.Data;

public class CellManagerContext : IdentityDbContext
{
    public DbSet<Cell> Cells { get; set; }
    public DbSet<Supervision> Supervisions { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Visitor> Visitors { get; set; }
    public DbSet<Event> Events { get; set; }

    public CellManagerContext(DbContextOptions<CellManagerContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.ApplyConfiguration(new CellsConfiguration());
        builder.ApplyConfiguration(new EventsConfiguration());

        SeedData(builder);
    }

    private void SeedData(ModelBuilder builder)
    {
        var adminRoleId = Guid.NewGuid().ToString();
        var adminUserId = Guid.NewGuid().ToString();

        var roles = new List<string>() { "Admin", "Supervisor", "Leader" };

        foreach (var role in roles)
        {
            var roleId = Guid.NewGuid().ToString();
            roleId = role == "Admin" ? adminRoleId : roleId;

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = roleId,
                Name = role,
                NormalizedName = role.ToUpper()
            });
        }

        var hasher = new PasswordHasher<IdentityUser>();

        builder.Entity<IdentityUser>().HasData(
            new IdentityUser
            {
                Id = adminUserId,
                Email = "admin@admin.com",
                NormalizedEmail = "admin@admin.com".ToUpper(),
                UserName = "admin",
                NormalizedUserName = "admin".ToUpper(),
                PasswordHash = hasher.HashPassword(null, "admin")
            }
        );

        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = adminRoleId,
                UserId = adminUserId
            }
        );
    }
}
