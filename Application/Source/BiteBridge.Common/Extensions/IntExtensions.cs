namespace BiteBridge.Common.Extensions;

public static class IntExtensions
{
	public static bool In(this int value, params int[] args) => args.Any(value.Equals);

	public static bool In(this int value, List<int> list) => list.Any(value.Equals);
}