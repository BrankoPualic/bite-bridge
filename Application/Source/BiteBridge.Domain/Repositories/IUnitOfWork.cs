namespace BiteBridge.Domain.Repositories;

public interface IUnitOfWork
{
	#region Repositories

	IErrorLogRepository ErrorLogRepository { get; }

	#endregion Repositories

	#region Methods

	void BeginTransaction();

	Task CommitTransactionAsync(CancellationToken cancellationToken = default);

	Task RollbackTransactionAsync(CancellationToken cancellationToken = default);

	Task<bool> Save();

	#endregion Methods
}