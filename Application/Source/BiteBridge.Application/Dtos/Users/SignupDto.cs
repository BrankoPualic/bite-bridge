using BiteBridge.Application.Dtos.Users.Objects;

namespace BiteBridge.Application.Dtos.Users;

public partial class SignupDto
{
	public string FirstName { get; set; } = string.Empty;
	public string? MiddleName { get; set; }
	public string LastName { get; set; } = string.Empty;
	public string Email { get; set; } = string.Empty;
	public string Password { get; set; } = string.Empty;
	public string ConfirmPassword { get; set; } = string.Empty;
	public DateTime DateOfBirth { get; set; }
	public string HomeNumber { get; set; } = string.Empty;
	public string? OfficeNumber { get; set; }
	public LocationDto Location { get; set; }

	public void ToModel(User user, IUserManager userManager)
	{
		user.FirstName = FirstName;
		user.LastName = LastName;
		user.Email = Email;
		user.Password = userManager.HashPassword(Password);
		user.DateOfBirth = DateOfBirth;
		user.HomeNumber = HomeNumber;
		user.OfficeNumber = OfficeNumber;

		Location.ToModel(user);

		user.UserRoles = [new UserRole
		{
			UserId = user.Id,
			RoleId = (int)eSystemRole.Member
		}];
	}
}
