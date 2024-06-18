using BiteBridge.Common.Enums;
using BiteBridge.Common.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BiteBridge.Application.BusinessLogic._Base;

public abstract class BaseHandler<TRequest> : IRequestHandler<TRequest>
	where TRequest : IRequest
{
	public abstract Task Handle(TRequest request, CancellationToken cancellationToken);

	protected bool TryRun(Action action, ILogger logger)
	{
		try
		{
			action();
			return true;
		}
		catch (Exception ex)
		{
			logger.LogError(ex, ex.Message);
			return false;
		}
	}

	protected async Task<bool> TryRunAsync(Func<Task> action, ILogger logger)
	{
		try
		{
			await action();
			return true;
		}
		catch (Exception ex)
		{
			logger.LogError(ex, ex.Message);
			return false;
		}
	}

	protected void CheckUserAuthorization(IIdentityUser user, params eSystemRole[] requiredRoles)
	{
		if (!user.IsAuthenticated || !user.Roles.Any(role => requiredRoles.Contains(role)))
		{
			throw new UnauthorizedAccessException();
		}
	}
}