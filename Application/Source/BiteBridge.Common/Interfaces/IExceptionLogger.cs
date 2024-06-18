namespace BiteBridge.Common.Interfaces;

public interface IExceptionLogger
{
	Guid LogException(Exception exception);
}