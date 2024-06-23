using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BiteBridge.Web.Api.Controllers._Base;

[Route("api/[controller]/[action]")]
[ApiController]
public abstract class BaseController(IMediator mediator) : ControllerBase
{
	private readonly IMediator _mediator = mediator;

	protected IMediator Mediator => _mediator;
}