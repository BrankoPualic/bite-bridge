namespace BiteBridge.Domain.Entities._Base;

public abstract class Entity : IEntity
{
	public Guid Id { get; set; }
	public bool IsActive { get; set; }
}