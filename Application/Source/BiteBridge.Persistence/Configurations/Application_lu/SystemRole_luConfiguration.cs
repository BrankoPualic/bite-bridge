using BiteBridge.Common.Enums;
using BiteBridge.Domain.Entities.Application_lu;
using BiteBridge.Persistence.Configurations._Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BiteBridge.Persistence.Configurations.Application_lu;

internal class SystemRole_luConfiguration : Entity_luConfiguration<SystemRole_lu>
{
	protected override void ConfigureEntity(EntityTypeBuilder<SystemRole_lu> builder)
	{
		builder.HasData(
			new SystemRole_lu { Id = (int)eSystemRole.Administrator, Name = eSystemRole.Administrator.ToString() },
			new SystemRole_lu { Id = (int)eSystemRole.UserAdmin, Name = eSystemRole.UserAdmin.ToString() },
			new SystemRole_lu { Id = (int)eSystemRole.Moderator, Name = eSystemRole.Moderator.ToString() },
			new SystemRole_lu { Id = (int)eSystemRole.Member, Name = eSystemRole.Member.ToString() },
			new SystemRole_lu { Id = (int)eSystemRole.Chef, Name = eSystemRole.Chef.ToString() }
			);
	}
}