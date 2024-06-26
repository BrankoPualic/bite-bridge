﻿using BiteBridge.Domain.Entities.Application;
using BiteBridge.Persistence.Configurations.Seeds.Application;
using BiteBridge.Persistence.Configurations.Seeds.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BiteBridge.Persistence.Configurations.Application;

internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
	public void Configure(EntityTypeBuilder<Category> builder)
	{
		builder.HasKey(x => x.Id);

		builder.Property(x => x.Name)
			.IsRequired()
			.HasMaxLength(30);

		builder.HasIndex(x => x.Name)
			.IsUnique();

		builder.HasData(SeedHelper.GetSeedData<Category, CategorySeed>());
	}
}