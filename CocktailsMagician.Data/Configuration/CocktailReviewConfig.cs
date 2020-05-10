using CocktailsMagician.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

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
