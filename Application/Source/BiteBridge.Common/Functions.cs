namespace BiteBridge.Common;

public static class Functions
{
	public static bool BeAtLeastEighteenYearsOld(DateTime dob) => dob <= DateTime.Today.AddYears(-18);

	public static string[] GetStringValuesFromEnums<T>(params T[] enumList)
	where T : struct, Enum
	{
		return enumList.Select(_ => _.ToString()).ToArray();
	}

	public static string GetUserFullName(string firstName, string lastName, string? middleName)
	{
		return string.Join(" ", firstName, middleName, lastName);
	}
}