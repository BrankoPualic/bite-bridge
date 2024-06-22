using BiteBridge.Domain.Repositories;
using BiteBridge.Persistence.Contexts;
using BiteBridge.Persistence.Repositories._Base;

namespace BiteBridge.Persistence.Repositories;

public class UnitOfWork : RepositoryContext, IUnitOfWork
{
	public UnitOfWork(ApplicationContext context) : base(context)
	{
	}

	#region Repositories

	public IErrorLogRepository ErrorLogRepository => new ErrorLogRepository(_context);

	public IUserRepository UserRepository => new UserRepository(_context);

	public IUserRoleRepository UserRoleRepository => new UserRoleRepository(_context);

	public ICategoryRepository CategoryRepository => new CategoryRepository(_context);

	#endregion Repositories

	#region Methods

	public async Task<bool> Save()
	{
		return await _context.SaveChangesAsync() > 0;
	}

	#endregion Methods
}