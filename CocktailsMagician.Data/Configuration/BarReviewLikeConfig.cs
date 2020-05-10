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
                builder.HasKey(br => new { br.BarId, br.UserLikeId, br.UserReviewId });
                builder.HasOne(br => br.UserLike)
                .WithMany(br => br.BarReviewLikes)
                .HasForeignKey(br => new { br.UserReviewId, br.BarId })
                .OnDelete(DeleteBehavior.Restrict);
        }
        }
    }
