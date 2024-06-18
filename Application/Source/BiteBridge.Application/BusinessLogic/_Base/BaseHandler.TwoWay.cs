using AutoMapper;
using BiteBridge.Common.Enums;
using BiteBridge.Common.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace BiteBridge.Application.BusinessLogic._Base;

public abstract class BaseHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
	where TRequest : IRequest<TResponse>
{
	#region Fields

	protected readonly IMediator _mediator;
	protected readonly IMapper _mapper;
	protected IIdentityUser _identityUser;
	protected ILogger _logger;

	#endregion Fields

	protected BaseHandler()
	{
	}

	//protected BaseHandler(IUnitOfWork unitOfWork) : this()
	//{
	//}

	//protected BaseHandler(IUnitOfWork unitOfWork, IMapper mapper = null, IIdentityUser identityUser = null, IMediator mediator = null, ILogger logger = null)
	//	: this(unitOfWork)
	//   {
	//       _mediator = mediator;
	//	_mapper = mapper;
	//	_identityUser = identityUser;
	//	_logger = logger;
	//   }

	public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);

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