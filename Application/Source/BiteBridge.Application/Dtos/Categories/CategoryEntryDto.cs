namespace BiteBridge.Application.Dtos.Categories;

public class CategoryEntryDto
{
	public string Name { get; set; } = string.Empty;
	public int? ParentId { get; set; }

	public void ToModel(Category category)
	{
		category.Name = Name;
		category.ParentId = ParentId;
	}
}