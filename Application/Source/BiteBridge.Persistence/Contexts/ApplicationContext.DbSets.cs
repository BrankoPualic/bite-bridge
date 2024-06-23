using BiteBridge.Domain.Entities.Application;
using BiteBridge.Domain.Entities.Application_lu;
using Microsoft.EntityFrameworkCore;

namespace BiteBridge.Persistence.Contexts;

public partial class ApplicationContext
{
	public virtual DbSet<ErrorLog> ErrorLogs { get; set; }
	public virtual DbSet<Category> Categories { get; set; }
	public virtual DbSet<User> Users { get; set; }
	public virtual DbSet<UserRole> UserRoles { get; set; }
	public virtual DbSet<SigninLog> SigninLogs { get; set; }

	// Lu Tabels
	public virtual DbSet<SystemRole_lu> SystemRoles_lu { get; set; }
}