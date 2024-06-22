using BiteBridge.Domain.Entities.Application;
using BiteBridge.Domain.Repositories;
using BiteBridge.Persistence.Contexts;
using BiteBridge.Persistence.Repositories._Base;
using BiteBridge.Persistence.Repositories.Helpers;
using Microsoft.EntityFrameworkCore;

namespace BiteBridge.Persistence.Repositories;

public class CategoryRepository : RepositoryContext, ICategoryRepository
{
	public CategoryRepository(ApplicationContext context) : base(context)
	{
	}

	public async Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken = default)
	{
		var allCategories = await _context.Categories
			.ToListAsync(cancellationToken);

		var topLevelCategories = allCategories
			.Where(_ => !_.ParentId.HasValue)
			.ToList();

		foreach (var category in topLevelCategories)
		{
			CategoryHelpers.LoadChildren(category, allCategories);
		}

		return topLevelCategories;
	}
}