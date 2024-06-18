using BiteBridge.Common.Interfaces;

namespace BiteBridge.Domain.Entities._Base;

public abstract partial class AuditableEntity
{
	private readonly IIdentityUser _identityUser;

	protected AuditableEntity(IIdentityUser identityUser)
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

	public virtual void Delete()
	{
		DeletedOn = DateTime.UtcNow;
		DeletedBy = _identityUser.Id;
	}

	public virtual void Deactivate()
	{
		Update();
		IsActive = false;
	}
}