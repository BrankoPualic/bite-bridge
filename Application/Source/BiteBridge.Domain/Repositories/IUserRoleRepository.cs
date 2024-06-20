using BiteBridge.Domain.Entities.Application;

namespace BiteBridge.Domain.Repositories;

public interface IUserRoleRepository
{
	Task<bool> AlreadyHasRoleAsync(UserRole userRole, CancellationToken cancellationToken = default);

	void Add(UserRole userRole);
}