
using CocktailsMagician.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Data.Configuration
{
    public class BarConfig : IEntityTypeConfiguration<Bar>
    {
        public void Configure(EntityTypeBuilder<Bar> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name).IsRequired().HasMaxLength(25);
            builder.HasIndex(b => b.Name).IsUnique();
            builder.HasIndex(b => b.Phone).IsUnique();
            builder.Property(b => b.Phone).IsRequired();
            builder.HasIndex(b => b.Website).IsUnique();
            builder.Property(b => b.Website).IsRequired();
        }
    }
}