namespace BiteBridge.Domain.Repositories;

public interface IUnitOfWork
{
	#region Repositories

	IErrorLogRepository ErrorLogRepository { get; }
	IUserRepository UserRepository { get; }
	IUserRoleRepository UserRoleRepository { get; }

	#endregion Repositories

	#region Methods

	Task<bool> Save();

	#endregion Methods
}