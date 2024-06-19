using BiteBridge.Domain.Entities.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BiteBridge.Persistence.Configurations.Application;

internal class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
	public void Configure(EntityTypeBuilder<UserRole> builder)
	{
		builder.HasKey(x => new { x.UserId, x.RoleId });
	}
}