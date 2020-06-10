using CocktailsMagician.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CocktailsMagician.Data.Configuration
{
    public class CocktailConfig : IEntityTypeConfiguration<Cocktail>
    {
        public void Configure(EntityTypeBuilder<Cocktail> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name).IsRequired().HasMaxLength(50);
            builder.HasIndex(b => b.Name).IsUnique();
        }
    }
}
