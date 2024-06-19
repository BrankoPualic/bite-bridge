using BiteBridge.Domain.Entities.Application;
using BiteBridge.Persistence.Configurations._Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BiteBridge.Persistence.Configurations;

internal class CategoryConfiguration : Entity_luConfiguration<Category>
{
    public CategoryConfiguration()
    {
    }

    protected override void ConfigureEntity(EntityTypeBuilder<Category> builder)
    {
        builder.Property(x => x.Description)
            .HasMaxLength(100);
    }
}