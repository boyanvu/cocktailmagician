using BeerOverflow.Data.Configuration;
using CocktailsMagician.Data.Configuration;
using CocktailsMagician.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CocktailsMagician.Data
{
    public class CMContext : DbContext
    {
        public CMContext(DbContextOptions<CMContext> options)
            : base(options)
        {
        }

        public DbSet<Bar> Bars { get; set; }
        public DbSet<Cocktail> Cocktails { get; set; }
        public DbSet<BarCocktail> BarCocktails { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<CocktailIngredients> CocktailIngredients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<IngredientType> IngredientTypes { get; set; }
        public DbSet<CocktailReview> CocktailReviews { get; set; }
        public DbSet<CocktailReviewLike> CocktailReviewLikes { get; set; }
        public DbSet<BarReviewLike> BarReviewLikes { get; set; }
        public DbSet<BarReview> BarReviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BarConfig());
            modelBuilder.ApplyConfiguration(new BarCocktailConfig());
            modelBuilder.ApplyConfiguration(new CocktailIngredientsConfig());
            modelBuilder.ApplyConfiguration(new IngredientConfig());
            modelBuilder.ApplyConfiguration(new BarReviewConfig());
            modelBuilder.ApplyConfiguration(new BarReviewLikeConfig());
            modelBuilder.ApplyConfiguration(new CityConfig());
            modelBuilder.ApplyConfiguration(new CocktailConfig());
            modelBuilder.ApplyConfiguration(new CocktailReviewConfig());
            modelBuilder.ApplyConfiguration(new CocktailReviewLikeConfig());
            modelBuilder.ApplyConfiguration(new IngredientTypeConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());

            //Seeder.Seeder.SeedDatabase(modelBuilder);

            //base.OnModelCreating(modelBuilder);

        }
    }
}
