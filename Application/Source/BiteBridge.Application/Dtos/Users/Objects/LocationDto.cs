using Newtonsoft.Json;

namespace BiteBridge.Application.Dtos.Users.Objects;

public partial class LocationDto
{
	public string PrimaryAddress { get; set; } = string.Empty;
	public string? SecondaryAddress { get; set; }
	public string City { get; set; } = string.Empty;
	public string State { get; set; } = string.Empty;
	public string ZipCode { get; set; } = string.Empty;

	public void ToModel(User user)
	{
		var location = new LocationDto
		{
			PrimaryAddress = PrimaryAddress,
			SecondaryAddress = SecondaryAddress,
			City = City,
			State = State,
			ZipCode = ZipCode,
		};

		user.DetailsJson = JsonConvert.SerializeObject(location, Constants.JSON_OPTIONS_NO_NULL_VALUES);
	}
}