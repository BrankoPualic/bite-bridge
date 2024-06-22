namespace BiteBridge.Application.Dtos.Categories;

public class CategoryResponseDto
{
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public int? ParentId { get; set; }
	public List<CategoryResponseDto>? SubCategories { get; set; } = [];
}