using BiteBridge.Domain.Entities.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BiteBridge.Persistence.Configurations;

internal class ErrorLogConfiguration : IEntityTypeConfiguration<ErrorLog>
{
	public void Configure(EntityTypeBuilder<ErrorLog> builder)
	{
		builder.HasKey(x => x.Id);

		builder.Property(x => x.Message).IsRequired();
	}
}