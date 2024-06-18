using BiteBridge.Common.Interfaces;
using BiteBridge.Domain.Entities.Application;
using BiteBridge.Domain.Repositories;

namespace BiteBridge.Infrastructure.Logger;

public class DbExceptionLogger : IExceptionLogger
{
	private readonly IUnitOfWork _unitOfWork;

	public DbExceptionLogger(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public Guid LogException(Exception exception)
	{
		var id = Guid.NewGuid();

		ErrorLog error = new()
		{
			Id = id,
			Message = exception.Message,
			StackTrace = exception.StackTrace,
			InnerException = exception.InnerException?.Message,
			CreatedOn = DateTime.UtcNow,
		};

		_unitOfWork.ErrorLogRepository.Add(error);

		_unitOfWork.Save();

		return id;
	}
}