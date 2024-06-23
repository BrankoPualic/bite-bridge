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

	public void Add(Category category) => _context.Categories.Add(category);

	public async Task<Category?> FindAsync(int id, CancellationToken cancellationToken = default)
	{
		return await _context.Categories.FindAsync([id], cancellationToken: cancellationToken);
	}

	public async Task<Category?> FindAsync(string name, CancellationToken cancellationToken = default)
	{
		return await _context.Categories.SingleOrDefaultAsync(_ => _.Name.Equals(name), cancellationToken);
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