namespace BiteBridge.Common.Extensions;

public static class StringExtensions
{
	public static bool HasValue(this string value) => !string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value);

	public static string AppendArgument(this string value, string argument) => $"{value} {argument}";

	public static string AppendArgument(this string value, params string[] args) => $"{value} {string.Join(", ", args)}";

	public static bool In(this string value, params string[] args) => args.Any(value.Equals);

	public static bool In(this string value, List<string> list) => list.Any(value.Equals);
}