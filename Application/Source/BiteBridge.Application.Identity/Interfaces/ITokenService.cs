namespace BiteBridge.Application.Identity.Interfaces;

public interface ITokenService
{
	string GenerateJwtToken(Guid userId, string[] roles, string username, string email);
}