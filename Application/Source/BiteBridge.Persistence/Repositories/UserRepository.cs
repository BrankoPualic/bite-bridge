using BiteBridge.Domain.Entities.Application;
using BiteBridge.Domain.Repositories;
using BiteBridge.Persistence.Contexts;
using BiteBridge.Persistence.Repositories._Base;
using Microsoft.EntityFrameworkCore;

namespace BiteBridge.Persistence.Repositories;

public class UserRepository : RepositoryContext, IUserRepository
{
	public UserRepository(ApplicationContext context) : base(context)
	{
	}

	public void Add(User user) => _context.Users.Add(user);

	public async Task<User> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default)
	{
		return await _context.Users
			.Include(_ => _.UserRoles)
			.ThenInclude(_ => _.Role)
			.SingleOrDefaultAsync(_ => _.Email.Equals(email), cancellationToken);
	}

	public void LogSignin(SigninLog log) => _context.SigninLogs.Add(log);

	public async Task<bool> UserExistAsync(string email, CancellationToken cancellationToken = default)
	{
		return await _context.Users.FirstOrDefaultAsync(_ => _.Email.Equals(email), cancellationToken) is not null;
	}
}