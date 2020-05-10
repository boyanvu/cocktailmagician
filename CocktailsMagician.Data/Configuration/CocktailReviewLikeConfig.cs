using CocktailsMagician.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailsMagician.Data.Configuration
{

    public class CocktailReviewLikeConfig : IEntityTypeConfiguration<CocktailReviewLike>
    {
        public void Configure(EntityTypeBuilder<CocktailReviewLike> builder)
        {
            builder.HasKey(crl => new { crl.CocktailReviewId,crl.UserId });
            builder.HasOne(crl => crl.User).WithMany(crl => crl.CocktailReviewLikes).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
