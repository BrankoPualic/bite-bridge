using BiteBridge.Application.BusinessLogic.Categories.Commands;
using BiteBridge.Application.BusinessLogic.Categories.Queries;
using BiteBridge.Application.Dtos.Categories;
using BiteBridge.Web.Api.Attributes;
using BiteBridge.Web.Api.Controllers._Base;
using BiteBridge.Web.Api.ReinforcedTypings.Generator;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BiteBridge.Web.Api.Controllers;

public class CategoryController(IMediator mediator) : BaseController(mediator)
{
	[HttpGet]
	[AngularMethod(typeof(IEnumerable<CategoryResponseDto>))]
	public async Task<IActionResult> GetAll() => Ok(await Mediator.Send(new GetCategoriesQuery()));

	[HttpPost]
	[Authorization(eSystemRole.Administrator, eSystemRole.Moderator)]
	[AngularMethod(typeof(void))]
	public async Task<IActionResult> Add(CategoryEntryDto category)
	{
		await Mediator.Send(new AddCategoryCommand(category));
		return Created();
	}

	[HttpPut("{id}")]
	[Authorization(eSystemRole.Administrator, eSystemRole.Moderator)]
	[AngularMethod(typeof(void))]
	public async Task<IActionResult> Update(int id, CategoryEntryDto category)
	{
		await Mediator.Send(new UpdateCategoryCommand(id, category));
		return NoContent();
	}

	[HttpDelete("{id}")]
	[Authorization(eSystemRole.Administrator, eSystemRole.Moderator)]
	[AngularMethod(typeof(void))]
	public async Task<IActionResult> Remove(int id)
	{
		await Mediator.Send(new RemoveCategoryCommand(id));
		return NoContent();
	}
}