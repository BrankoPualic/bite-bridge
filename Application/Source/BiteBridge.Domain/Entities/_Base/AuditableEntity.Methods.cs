using BiteBridge.Common.Interfaces;

namespace BiteBridge.Domain.Entities._Base;

public abstract partial class AuditableEntity
{
	private readonly IIdentityUser _identityUser;

	protected AuditableEntity()
	{
	}

	protected AuditableEntity(IIdentityUser identityUser)
		: this()
	{
		_identityUser = identityUser;
	}

	public virtual void Create()
	{
		CreatedOn = DateTime.UtcNow;
		IsActive = true;
	}

	public virtual void Update()
	{
		ModifiedOn = DateTime.UtcNow;
		ModifiedBy = _identityUser.Id;
	}

	public virtual void Deactivate()
	{
		Update();
		IsActive = false;
	}
}