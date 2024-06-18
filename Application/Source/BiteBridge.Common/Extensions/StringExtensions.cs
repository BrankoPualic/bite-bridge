namespace BiteBridge.Common.Extensions;

public static class StringExtensions
{
	public static bool HasValue(this string value)
	{
		return !string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value);
	}

	public static string AppendArgument(this string value, string argument)
	{
		return $"{value} {argument}";
	}
}