using BiteBridge.Application.Identity.Interfaces;

namespace BiteBridge.Application.Identity.Services;

public class UserManager : IUserManager
{
	public string HashPassword(string password)
	{
		return BCrypt.Net.BCrypt.HashPassword(password);
	}

	public bool VerifyPassword(string password, string storedPassword)
	{
		return BCrypt.Net.BCrypt.Verify(password, storedPassword);
	}
}