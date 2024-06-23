using BiteBridge.Domain.Entities.Application;
using BiteBridge.Persistence.Contexts;

namespace BiteBridge.Persistence.Repositories.Helpers;

public static class CategoryHelpers
{
	public static void LoadChildren(Category parent, IEnumerable<Category> allCategories)
	{
		parent.Children = allCategories
			.Where(_ => _.ParentId.Equals(parent.Id))
			.ToList();

		foreach (var child in parent.Children)
		{
			LoadChildren(child, allCategories);
		}
	}
}