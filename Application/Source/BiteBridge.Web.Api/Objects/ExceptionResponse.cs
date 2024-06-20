namespace BiteBridge.Web.Api.Objects;

public class ExceptionResponse
{
	public string Message { get; set; } = string.Empty;
}

public class ValidationExceptionResponse : ExceptionResponse
{
	public Dictionary<string, string[]> Error { get; set; } = [];
}