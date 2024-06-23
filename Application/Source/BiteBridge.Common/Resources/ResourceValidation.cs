namespace BiteBridge.Common.Resources;

public static class ResourceValidation
{
	public static string Record_Doesnt_Exist => "Record doesn't exist.";
	public static string Required => "Field is required.";
	public static string Maximum_Characters => "Maximum number of characters exceeded.";
	public static string Minimum_Characters => "Minimum number of characters not reached.";
	public static string Wrong_Format => "Input is in the wrong format.";
	public static string Password => "Password must consist of at least one uppercase letter, one lowercase letter, one digit, one special character and must be at least 8 characters long.";
	public static string Dont_Match => "Fields don't match.";
	public static string Minimum_Age => "Minimum age.";
	public static string Entity_Already_Exist => "Entity already exist.";
	public static string Phone_Number => "Phone number must be in format 333-333-3333.";
	public static string Zip_Code => "Zip code must be in format 5 digits or 5 digits followed by hypen and 4 more digits.";
	public static string Wrong_Credentials => "User credentials are wrong. Please try again.";
	public static string Record_Already_Exist => "Record already exist.";
}