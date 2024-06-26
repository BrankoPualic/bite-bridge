﻿using BiteBridge.Domain.Entities.Application;

namespace BiteBridge.Domain.Repositories;

public interface IUserRepository
{
	Task<bool> UserExistAsync(string email, CancellationToken cancellationToken = default);

	void Add(User user);

	void LogSignin(SigninLog log);

	Task<User> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default);
}