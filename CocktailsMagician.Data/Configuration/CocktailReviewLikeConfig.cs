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
            builder.HasKey(cr=> new {cr.CocktailId, cr.UserReviewId, cr.UserLikeId });
            builder.HasOne(cr => cr.UserLike)
            .WithMany(cr => cr.CocktailReviewLikes)
            .HasForeignKey(cr => new { cr.UserReviewId, cr.CocktailId })
            .OnDelete(DeleteBehavior.Restrict);

    //        modelBuilder.Entity<ShippingDetail>()
    //.HasMany(e => e.Analysis)
    //.WithOne() // make sure to specify navigation property if exists, e.g. e => e.NavProp
    //.HasForeignKey(e => new { e.ShipmentId, e.ProductId });
        }
    }
}
