using CocktailsMagician.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailsMagician.Data.Configuration
{

    public class BarReviewLikeConfig : IEntityTypeConfiguration<BarReviewLike>
    {
        public void Configure(EntityTypeBuilder<BarReviewLike> builder)
        {
            builder.HasKey(brl => new { brl.BarReviewId,brl.UserId});
            builder.HasOne(brl => brl.User).WithMany(brl => brl.BarReviewLikes).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
