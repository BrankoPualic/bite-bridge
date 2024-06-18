using BiteBridge.Domain.Entities._Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BiteBridge.Persistence.Configurations._Base;

internal abstract class Entity_luConfiguration<T> : IEntityTypeConfiguration<T>
	where T : Entity_lu
{
	public virtual void Configure(EntityTypeBuilder<T> builder)
	{
		builder.HasKey(x => x.Id);

		builder.Property(x => x.Name)
			.IsRequired()
			.HasMaxLength(30);

		builder.HasIndex(x => x.Name)
			.IsUnique();

		ConfigureEntity(builder);
	}

	protected abstract void ConfigureEntity(EntityTypeBuilder<T> builder);
}