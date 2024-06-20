namespace BiteBridge.Common.Extensions;

public static class EnumExtensions
{
	public static List<T> GetEnumList<T>(this string enumsString)
		where T : struct, Enum
	{
		if (enumsString.HasValue())
		{
			return new List<T>();
		}

		var enums = enumsString.Split(',')
			.Select(e => Enum.TryParse<T>(e.Trim(), out var parsedEnum) ? parsedEnum : (T?)null)
			.Where(parsedEnum => parsedEnum.HasValue)
			.Select(parsedEnum => parsedEnum.Value)
			.ToList();

		return enums;
	}
}