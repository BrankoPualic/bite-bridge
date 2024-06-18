using BiteBridge.Web.Api.Attributes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BiteBridge.Web.Api.Controllers._Base;

[Route("api/[controller]/[action]")]
[ApiController]
public abstract class BaseController : ControllerBase
{
	private readonly IMediator _mediator;

	protected BaseController(IMediator mediator)
	{
		_mediator = mediator;
	}

	protected IMediator Mediator => _mediator;
}