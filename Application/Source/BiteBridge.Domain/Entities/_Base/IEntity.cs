namespace BiteBridge.Domain.Entities._Base;

public interface IEntity
{
	Guid Id { get; set; }
	bool IsActive { get; set; }
}