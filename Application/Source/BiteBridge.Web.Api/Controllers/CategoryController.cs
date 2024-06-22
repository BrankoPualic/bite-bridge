using BiteBridge.Application.BusinessLogic.Categories.Queries;
using BiteBridge.Application.Dtos.Categories;
using BiteBridge.Web.Api.Controllers._Base;
using BiteBridge.Web.Api.ReinforcedTypings.Generator;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BiteBridge.Web.Api.Controllers;

public class CategoryController : BaseController
{
	public CategoryController(IMediator mediator) : base(mediator)
	{
	}

	[HttpGet]
	[AngularMethod(typeof(IEnumerable<CategoryResponseDto>))]
	public async Task<IActionResult> GetAll() => Ok(await Mediator.Send(new GetCategoriesQuery()));
}