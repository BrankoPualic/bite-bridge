using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace BiteBridge.Common;

public static class Constants
{
	public const string SOLUTION_NAME = "BiteBridge";
	public const int TOKEN_EXPIRATION_TIME = 7;
	public const string SYSTEM_USER_ID = "00000000-0000-0000-0000-000000000001";

	// Claims

	public const string CLAIM_ID = "NAMEIDENTIFIER";
	public const string CLAIM_USERNAME = "NAME";
	public const string CLAIM_ROLES = "ROLES";
	public const string CLAIM_EMAIL = "EMAIL";

	// Validations

	public static readonly Regex REGEX_PASSWORD = new(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{8,}$");
	public static readonly Regex REGEX_ZIPCODE = new(@"^\d{5}(-\d{4})?$");
	public static readonly Regex REGEX_PHONE_NUMBER = new(@"^\d{3}-\d{3}-\d{4}$");

	// Json Converter Settings

	public static readonly JsonSerializerSettings JSON_OPTIONS_NO_NULL_VALUES = new() { NullValueHandling = NullValueHandling.Ignore };
}