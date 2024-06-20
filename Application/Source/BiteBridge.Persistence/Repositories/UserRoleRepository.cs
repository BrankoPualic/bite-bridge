using BiteBridge.Domain.Entities.Application;
using BiteBridge.Domain.Repositories;
using BiteBridge.Persistence.Contexts;
using BiteBridge.Persistence.Repositories._Base;
using Microsoft.EntityFrameworkCore;

namespace BiteBridge.Persistence.Repositories;

public class UserRoleRepository : RepositoryContext, IUserRoleRepository
{
	public UserRoleRepository(ApplicationContext context) : base(context)
	{
	}

	public void Add(UserRole userRole)
	{
		_context.UserRoles.Add(userRole);
	}

	public async Task<bool> AlreadyHasRoleAsync(UserRole userRole, CancellationToken cancellationToken = default)
	{
		return await _context.UserRoles.SingleOrDefaultAsync(
			_ => _.UserId.Equals(userRole.UserId)
			&& _.RoleId.Equals(userRole.RoleId)
			, cancellationToken) is not null;
	}
}