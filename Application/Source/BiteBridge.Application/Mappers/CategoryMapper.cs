using BiteBridge.Application.Dtos.Categories;
using BiteBridge.Application.Mappers._Base;

namespace BiteBridge.Application.Mappers;

public class CategoryMapper : MapperProfile
{
	public CategoryMapper()
	{
		CreateMap<Category, CategoryResponseDto>()
			.ForMember(_ => _.SubCategories, opt => opt.MapFrom(src => src.Children));
	}
}