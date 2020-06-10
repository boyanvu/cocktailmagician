using CocktailsMagician.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CocktailsMagician.Data.Configuration
{
    public class CocktailReviewConfig : IEntityTypeConfiguration<CocktailReview>
    {
        public void Configure(EntityTypeBuilder<CocktailReview> builder)
        {
            builder.HasKey(cr => cr.Id);
            builder.HasIndex(cr => new { cr.CocktailId, cr.UserId }).IsUnique();
            builder.Property(cr => cr.Rating).IsRequired();
        }
    }
}
