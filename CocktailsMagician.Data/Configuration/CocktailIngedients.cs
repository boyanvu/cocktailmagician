using CocktailsMagician.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CocktailsMagician.Data.Configuration
{
    public class CocktailIngredientsConfig : IEntityTypeConfiguration<CocktailIngredients>
    {
        public void Configure(EntityTypeBuilder<CocktailIngredients> builder)
        {
            builder.HasKey(ci => new { ci.CocktailId, ci.IngredientId });
            //builder.Property(ci => ci.Quantity).IsRequired();
            //builder.Property(ci => ci.Uom).IsRequired();
        }
    }
}
