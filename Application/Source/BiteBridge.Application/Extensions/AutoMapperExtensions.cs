namespace BiteBridge.Application.Extensions;

public static class AutoMapperExtensions
{
	public static TDestination To<TDestination>(this IMapper mapper, object source)
	{
		return mapper.Map<TDestination>(source);
	}

	public static IEnumerable<TDestination> To<TDestination>(this IMapper mapper, IEnumerable<object> source)
	{
		return mapper.Map<IEnumerable<TDestination>>(source);
	}
}