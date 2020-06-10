using CocktailsMagician.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CocktailsMagician.Data.Configuration
{
    public class BarCocktailConfig : IEntityTypeConfiguration<BarCocktail>
    {
        public void Configure(EntityTypeBuilder<BarCocktail> builder)
        {
            builder.HasKey(bc => new { bc.BarId , bc.CocktailId });
        }
    }
}
