using CocktailsMagician.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailsMagician.Data.Configuration
{
    public class BarReviewConfig : IEntityTypeConfiguration<BarReview>
    {
        public void Configure(EntityTypeBuilder<BarReview> builder)
        {
            builder.HasKey(br => new { br.BarId, br.UserId });
            builder.Property(br => br.Rating).IsRequired();
        }
    }
}
