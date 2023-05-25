using Core.Entities;
using Core.Entities.PollEntities;
using Core.Entities.SystemEntities;
using Core.Models;

namespace EntityFramework;

public class ContextBase : DbContext
{
    public DbSet<SystemUser> SystemUsers { get; set; }
    public DbSet<SystemConfig> SystemConfigs { get; set; }
    public DbSet<SystemRole> SystemRoles { get; set; }
    public DbSet<SystemMenu> SystemMenus { get; set; }
    public DbSet<SystemPermission> SystemPermissions { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }
    public DbSet<SystemLogs> SystemLogs { get; set; }
    public DbSet<SystemOrganization> SystemOrganizations { get; set; }

    #region poll entities
    public DbSet<PollIssue> PollIssues { get; set; }
    public DbSet<PollOption> PollOptions { get; set; }
    public DbSet<PollCategory> PollCategories { get; set; }
    public DbSet<PollTag> PollTags { get; set; }
    #endregion


    public DbSet<User> Users { get; set; }

    public ContextBase(DbContextOptions options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        _ = builder.Entity<EntityBase>().UseTpcMappingStrategy();
        base.OnModelCreating(builder);
    }
}
