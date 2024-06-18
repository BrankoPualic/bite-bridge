using BiteBridge.Persistence.Contexts;

namespace BiteBridge.Persistence.Repositories._Base;

public abstract class RepositoryContext : IDisposable
{
	protected readonly ApplicationContext _context;

	protected RepositoryContext(ApplicationContext context)
	{
		_context = context;
	}

	public void Dispose()
	{
		_context.Dispose();
	}
}