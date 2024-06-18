using BiteBridge.Domain.Repositories;
using BiteBridge.Persistence.Contexts;
using BiteBridge.Persistence.Repositories._Base;

namespace BiteBridge.Persistence.Repositories;

public class UnitOfWork : RepositoryContext, IUnitOfWork
{
	public UnitOfWork(ApplicationContext context) : base(context)
	{
	}

	public IErrorLogRepository ErrorLogRepository => throw new NotImplementedException();

	public void BeginTransaction()
	{
		if (_context.Database.CurrentTransaction is null)
		{
			_context.Database.BeginTransaction();
		}
	}

	public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
	{
		if (_context.Database.CurrentTransaction is not null)
		{
			await _context.SaveChangesAsync(cancellationToken);
			await _context.Database.CurrentTransaction.CommitAsync(cancellationToken);
		}
	}

	public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
	{
		if (_context.Database.CurrentTransaction is not null)
		{
			await _context.Database.CurrentTransaction.RollbackAsync(cancellationToken);
		}
	}

	public async Task<bool> Save()
	{
		return await _context.SaveChangesAsync() > 0;
	}
}