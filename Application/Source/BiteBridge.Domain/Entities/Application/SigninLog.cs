namespace BiteBridge.Domain.Entities.Application;

public class SigninLog
{
	public Guid Id { get; set; }
	public Guid UserId { get; set; }
	public DateTime RecordDate { get; set; }
}