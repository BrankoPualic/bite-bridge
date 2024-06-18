namespace BiteBridge.Domain.Entities.Application;

public class ErrorLog
{
	public Guid Id { get; set; }
	public string Message { get; set; } = string.Empty;
	public string? StackTrace { get; set; }
	public string? InnerException { get; set; }
	public DateTime CreatedOn { get; set; }
}