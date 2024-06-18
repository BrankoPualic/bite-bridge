using BiteBridge.Domain.Repositories;
using MediatR;

namespace BiteBridge.Application.BusinessLogic._Behaviors;

public class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
	where TRequest : notnull
{
	private readonly IUnitOfWork _unitOfWork;

	public TransactionBehavior(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
	{
		_unitOfWork.BeginTransaction();

		try
		{
			var response = await next();

			await _unitOfWork.CommitTransactionAsync(cancellationToken);

			return response;
		}
		catch (Exception)
		{
			await _unitOfWork.RollbackTransactionAsync(cancellationToken);
			throw;
		}
	}
}