using BiteBridge.Domain.Entities._Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BiteBridge.Persistence.Configurations._Base;

internal abstract class EntityConfiguration<T> : IEntityTypeConfiguration<T>
	where T : Entity
{
	public virtual void Configure(EntityTypeBuilder<T> builder)
	{
		builder.HasKey(x => x.Id);

		builder.Property(x => x.IsActive)
			.HasDefaultValue(true);

		ConfigureEntity(builder);
	}

	protected abstract void ConfigureEntity(EntityTypeBuilder<T> builder);
}