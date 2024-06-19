using BiteBridge.Common.Enums;
using BiteBridge.Domain.Entities.Application_lu;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiteBridge.Domain.Entities.Application;

public class UserRole
{
	public Guid UserId { get; set; }
	public int RoleId { get; set; }

	[ForeignKey(nameof(UserId))]
	public virtual User User { get; set; }

	[ForeignKey(nameof(RoleId))]
	public virtual SystemRole_lu Role { get; set; }
}