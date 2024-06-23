using BiteBridge.Application.Identity.Interfaces;
using BiteBridge.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;

namespace BiteBridge.Application.Identity.Services;

public class TokenService : ITokenService
{
	private readonly IConfiguration _configuration;

	public TokenService(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	public string GenerateJwtToken(Guid userId, string[] roles, string fullName, string email)
	{
		IConfiguration secrets = new ConfigurationBuilder()
			.AddUserSecrets(Assembly.GetExecutingAssembly())
			.Build();

		var tokenHandler = new JwtSecurityTokenHandler();

		var jwtSecrets = new
		{
			Key = Encoding.UTF8.GetBytes(secrets["JWT_KEY"]!),
			Issuer = _configuration["Jwt:Issuer"],
			Audience = _configuration["Jwt:Audience"]
		};

		var claims = new List<Claim>
		{
			new(JwtRegisteredClaimNames.NameId, userId.ToString()),
			new(JwtRegisteredClaimNames.Iss, jwtSecrets.Issuer!),
			new(JwtRegisteredClaimNames.Name, Regex.Replace(fullName, @"\s{2}", " ")),
			new(JwtRegisteredClaimNames.Email, email)
		};

		claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

		var tokenDescriptor = new SecurityTokenDescriptor
		{
			Issuer = jwtSecrets.Issuer,
			Audience = jwtSecrets.Audience,
			Expires = DateTime.UtcNow.AddDays(Constants.TOKEN_EXPIRATION_TIME),
			SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(jwtSecrets.Key), SecurityAlgorithms.HmacSha512Signature),
			Claims = claims.ToDictionary(claim => claim.Type, claim => (object)claim.Value)
		};

		var token = tokenHandler.CreateToken(tokenDescriptor);

		return tokenHandler.WriteToken(token);
	}
}