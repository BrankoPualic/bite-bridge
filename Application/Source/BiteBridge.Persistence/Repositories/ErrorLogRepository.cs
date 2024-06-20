using BiteBridge.Domain.Entities.Application;
using BiteBridge.Domain.Repositories;
using BiteBridge.Persistence.Contexts;
using BiteBridge.Persistence.Repositories._Base;

namespace BiteBridge.Persistence.Repositories;

public class ErrorLogRepository : RepositoryContext, IErrorLogRepository
{
	public ErrorLogRepository(ApplicationContext context) : base(context)
	{
	}

	public void Add(ErrorLog error)
	{
		_context.ErrorLogs.Add(error);
	}
}