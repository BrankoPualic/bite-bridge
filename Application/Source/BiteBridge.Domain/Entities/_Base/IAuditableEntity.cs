namespace BiteBridge.Domain.Entities._Base;

public interface IAuditableEntity
{
	DateTime CreatedOn { get; set; }
	DateTime? ModifiedOn { get; set; }
	Guid? ModifiedBy { get; set; }
	DateTime? DeletedOn { get; set; }
	Guid? DeletedBy { get; set; }

	abstract void Create();

	abstract void Update();

	abstract void Delete();

	abstract void Deactivate();
}