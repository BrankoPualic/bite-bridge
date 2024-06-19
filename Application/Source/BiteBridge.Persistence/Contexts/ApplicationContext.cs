using BiteBridge.Domain.Entities._Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace BiteBridge.Persistence.Contexts;

public partial class ApplicationContext : DbContext
{
    public ApplicationContext()
    {
    }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddUserSecrets(Assembly.GetExecutingAssembly())
                .Build();


            optionsBuilder.UseSqlServer(configuration["LOCAL_DEV_DB_CONNECTION"]);
        }

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public override int SaveChanges()
    {
        Save();

        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        Save();

        return base.SaveChangesAsync(cancellationToken);
    }

    private void Save()
    {
        IEnumerable<EntityEntry> entries = this.ChangeTracker.Entries();

        foreach (EntityEntry entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                if (entry.Entity is AuditableEntity e)
                {
                    e.Create();
                }
            }

            if (entry.State == EntityState.Modified)
            {
                if (entry.Entity is AuditableEntity e)
                {
                    e.Update();
                }
            }
}