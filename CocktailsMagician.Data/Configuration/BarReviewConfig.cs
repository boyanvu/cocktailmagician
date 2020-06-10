using CocktailsMagician.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CocktailsMagician.Data.Configuration
{
    public class BarReviewConfig : IEntityTypeConfiguration<BarReview>
    {
        public void Configure(EntityTypeBuilder<BarReview> builder)
        {
            builder.HasKey(br => br.Id);
            builder.HasIndex(br => new { br.BarId, br.UserId }).IsUnique();
            builder.Property(br => br.Rating).IsRequired();
        }
    }
}
