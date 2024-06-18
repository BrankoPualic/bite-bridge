namespace BiteBridge.Domain.Entities._Base;

public abstract partial class AuditableEntity : Entity, IAuditableEntity
{
	public DateTime CreatedOn { get; set; }
	public DateTime? ModifiedOn { get; set; }
	public Guid? ModifiedBy { get; set; }
	public DateTime? DeletedOn { get; set; }
	public Guid? DeletedBy { get; set; }
}