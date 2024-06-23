using BiteBridge.Domain.Entities.Application;
using BiteBridge.Domain.Repositories;
using BiteBridge.Persistence.Contexts;
using BiteBridge.Persistence.Repositories._Base;

namespace BiteBridge.Persistence.Repositories;

public class ErrorLogRepository(ApplicationContext context) : RepositoryContext(context), IErrorLogRepository
{
	public void Add(ErrorLog error) => _context.ErrorLogs.Add(error);
}