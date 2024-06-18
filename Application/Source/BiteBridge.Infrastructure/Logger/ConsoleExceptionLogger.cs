using BiteBridge.Common.Interfaces;
using Serilog;

namespace BiteBridge.Infrastructure.Logger;

public class ConsoleExceptionLogger : IExceptionLogger
{
	public Guid LogException(Exception exception)
	{
		var id = Guid.NewGuid();
		Log.Error(exception, $"An Error occurred\nID: {id}\n {exception.Message}");

		return id;
	}
}