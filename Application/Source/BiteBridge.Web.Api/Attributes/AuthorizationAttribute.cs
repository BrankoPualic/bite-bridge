using BiteBridge.Common.Enums;
using BiteBridge.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BiteBridge.Web.Api.Attributes;

public class AuthorizationAttribute : Attribute, IAuthorizationFilter
{
	private readonly eSystemRole[] _roles;

	public AuthorizationAttribute(params eSystemRole[] roles)
	{
		_roles = roles;
	}

	public void OnAuthorization(AuthorizationFilterContext context)
	{
		var user = context.HttpContext.RequestServices.GetService<IIdentityUser>();

		if (user is null || !user.IsAuthenticated)
		{
			context.Result = new UnauthorizedResult();
			return;
		}

		if (!user.HasRole([.. _roles]))
		{
			context.Result = new ForbidResult();
		}
	}
}