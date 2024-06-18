using BiteBridge.Domain.Entities.Application;

namespace BiteBridge.Domain.Repositories;

public interface IErrorLogRepository
{
	void Add(ErrorLog error);
}