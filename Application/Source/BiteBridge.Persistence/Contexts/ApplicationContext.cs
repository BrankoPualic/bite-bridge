using BiteBridge.Domain.Entities._Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BiteBridge.Persistence.Contexts;

public partial class ApplicationContext : DbContext
{
	private readonly string _connectionString;

	public ApplicationContext()
	{
		_connectionString = "Data Source=localhost;Initial Catalog=LinkUp;TrustServerCertificate=true;Integrated security=true";
	}

	public ApplicationContext(string connectionString) : base()
	{
		_connectionString = connectionString;
	}

	public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
	{
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		if (!optionsBuilder.IsConfigured)
		{
			optionsBuilder.UseSqlServer(_connectionString);
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

			if (entry.State == EntityState.Deleted)
			{
				if (entry.Entity is AuditableEntity e)
				{
					e.Delete();
				}
			}
		}
	}
}