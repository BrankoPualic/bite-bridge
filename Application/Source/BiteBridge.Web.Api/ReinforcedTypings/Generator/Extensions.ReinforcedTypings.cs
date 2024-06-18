using Reinforced.Typings.Ast.TypeNames;

namespace BiteBridge.Web.Api.ReinforcedTypings.Generator;

public static class Extensions
{
	public static bool IsString(this RtTypeName typeName)
	{
		return typeName.ToString().ToLower() == "string";
	}
}