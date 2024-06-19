using BiteBridge.Domain.Entities._Base;
using BiteBridge.Domain.Entities.Application;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiteBridge.Domain.Entities.Application_lu;

public class SystemRole_lu : Entity_lu
{
	[InverseProperty("Role")]
	public ICollection<UserRole> UserRoles { get; set; }
}