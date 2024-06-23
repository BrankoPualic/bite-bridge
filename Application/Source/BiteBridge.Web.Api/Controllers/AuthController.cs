using BiteBridge.Application.BusinessLogic.Users.Commands;
using BiteBridge.Application.Dtos.Users;
using BiteBridge.Application.Dtos.Users.Authorization;
using BiteBridge.Web.Api.Controllers._Base;
using BiteBridge.Web.Api.ReinforcedTypings.Generator;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BiteBridge.Web.Api.Controllers;

public class AuthController(IMediator mediator) : BaseController(mediator)
{
	[HttpPost]
	[AngularMethod(typeof(AuthorizationDto))]
	public async Task<IActionResult> Signup(SignupDto user) => Ok(await Mediator.Send(new SignupCommand(user)));

	[HttpPost]
	[AngularMethod(typeof(AuthorizationDto))]
	public async Task<IActionResult> Signin(SigninDto user) => Ok(await Mediator.Send(new SigninCommand(user)));
}
