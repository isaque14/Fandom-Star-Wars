﻿using FandomStarWars.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FandomStarWars.Infra.Data.EntityConfiguration
{
    internal class PersonageConfiguration : IEntityTypeConfiguration<Personage>
    {
        public void Configure(EntityTypeBuilder<Personage> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Created).IsRequired();
        }
    }
}
