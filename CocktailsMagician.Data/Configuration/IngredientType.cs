using CocktailsMagician.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CocktailsMagician.Data.Configuration
{
    public class IngredientTypeConfig : IEntityTypeConfiguration<IngredientType>
    {
        public void Configure(EntityTypeBuilder<IngredientType> builder)
        {
            builder.HasKey(it => it.Id);
            builder.Property(it => it.Name).IsRequired();
            builder.HasIndex(it => it.Name).IsUnique();
        }
    }
}
