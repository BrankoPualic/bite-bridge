using BiteBridge.Domain.Entities.Application;

namespace BiteBridge.Domain.Repositories;

public interface ICategoryRepository
{
	Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken = default);

	Task<Category?> FindAsync(int id, CancellationToken cancellationToken = default);

	Task<Category?> FindAsync(string name, CancellationToken cancellationToken = default);

	void Add(Category category);

	void Remove(Category category);
}