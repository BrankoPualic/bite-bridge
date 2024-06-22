using BiteBridge.Domain.Entities.Application;

namespace BiteBridge.Domain.Repositories;

public interface ICategoryRepository
{
	Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken = default);
}