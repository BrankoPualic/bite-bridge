using BiteBridge.Common.Interfaces;
using BiteBridge.Domain.Entities._Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiteBridge.Domain.Entities.Application;

public class User : AuditableEntity
{
	public User() : base()
	{
	}

	public User(IIdentityUser identityUser) : base(identityUser)
	{
	}

	public string FirstName { get; set; } = string.Empty;
	public string? MiddleName { get; set; }
	public string LastName { get; set; } = string.Empty;
	public string Email { get; set; } = string.Empty;
	public string Password { get; set; } = string.Empty;
	public DateTime DateOfBirth { get; set; }
	public string HomeNumber { get; set; } = string.Empty;
	public string? OfficeNumber { get; set; }
	public string DetailsJson { get; set; } = string.Empty;

	[InverseProperty(nameof(User))]
	public ICollection<UserRole> UserRoles { get; set; } = [];
}