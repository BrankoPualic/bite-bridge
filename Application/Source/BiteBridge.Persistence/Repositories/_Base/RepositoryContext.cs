using BiteBridge.Persistence.Contexts;

namespace BiteBridge.Persistence.Repositories._Base;

public abstract class RepositoryContext(ApplicationContext context) : IDisposable
{
	protected readonly ApplicationContext _context = context;

	public void Dispose() => _context.Dispose();
}