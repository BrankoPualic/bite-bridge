using BiteBridge.Application.Identity.Interfaces;
using BiteBridge.Common;
using BiteBridge.Common.Enums;
using BiteBridge.Domain.Entities.Application;
using Newtonsoft.Json;

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
	public string PrimaryAddress { get; set; } = string.Empty;
	public string? SecondaryAddress { get; set; }
	public string State { get; set; } = string.Empty;
	public string ZipCode { get; set; } = string.Empty;
}

public partial class SignupDto
{
	public void ToModel(User user, IUserManager userManager)
	{
		user.FirstName = FirstName;
		user.LastName = LastName;
		user.Email = Email;
		user.Password = userManager.HashPassword(Password);
		user.DateOfBirth = DateOfBirth;
		user.HomeNumber = HomeNumber;
		user.OfficeNumber = OfficeNumber;

		var location = new
		{
			FirstAddress = PrimaryAddress,
			SecondAddress = SecondaryAddress,
			State = State,
			ZipCode = ZipCode,
		};

		user.DetailsJson = JsonConvert.SerializeObject(location, Constants.JSON_OPTIONS_NO_NULL_VALUES);

		user.UserRoles = [new UserRole
		{
			UserId = user.Id,
			RoleId = (int)eSystemRole.Member
		}];
	}
}