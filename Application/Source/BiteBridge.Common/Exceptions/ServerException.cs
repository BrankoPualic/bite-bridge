namespace BiteBridge.Common.Exceptions;

public class ServerException : Exception
{
	public ServerException()
		: base("Something went wrong. Please contact administrator for more details.")
	{
	}
}