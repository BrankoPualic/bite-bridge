using BiteBridge.Domain.Entities.Application;
using BiteBridge.Persistence.Configurations._Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BiteBridge.Persistence.Configurations.Application;

internal class UserConfiguration : EntityConfiguration<User>
{
	protected override void ConfigureEntity(EntityTypeBuilder<User> builder)
	{
		builder.Property(x => x.FirstName)
			.IsRequired()
			.HasMaxLength(20);

		builder.Property(x => x.MiddleName)
			.HasMaxLength(20);

		builder.Property(x => x.LastName)
			.IsRequired()
			.HasMaxLength(30);

		builder.Property(x => x.Email)
			.IsRequired()
			.HasMaxLength(60);

		builder.HasIndex(x => x.Email)
			.IsUnique();

		builder.Property(x => x.Password)
			.IsRequired()
			.HasMaxLength(30);

		builder.Property(x => x.HomeNumber)
			.IsRequired()
			.HasMaxLength(15);

		builder.Property(x => x.OfficeNumber)
			.HasMaxLength(15);

		builder.HasIndex(x => new
		{
			x.FirstName,
			x.MiddleName,
			x.LastName,
		}).IncludeProperties(x => x.DateOfBirth);
	}
}