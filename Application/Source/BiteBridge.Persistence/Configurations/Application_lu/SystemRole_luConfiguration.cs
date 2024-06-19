using BiteBridge.Domain.Entities.Application_lu;
using BiteBridge.Persistence.Configurations._Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BiteBridge.Persistence.Configurations.Application_lu;

internal class SystemRole_luConfiguration : Entity_luConfiguration<SystemRole_lu>
{
    protected override void ConfigureEntity(EntityTypeBuilder<SystemRole_lu> builder)
    {
    }
}