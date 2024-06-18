namespace BiteBridge.Common.Extensions;

public static class BoolExtensions
{
	public static bool In<T>(this T value, params T[] list) => list.Any(_ => _!.Equals(value));

	public static bool In<T>(this T value, List<T> list) => list.Any(_ => _!.Equals(value));
}