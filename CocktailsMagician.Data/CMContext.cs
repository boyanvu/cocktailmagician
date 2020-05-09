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
        public DbSet<BarReview> BarReviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.ApplyConfiguration(new CountryConfig());
            //modelBuilder.ApplyConfiguration(new BeerConfig());
            //modelBuilder.ApplyConfiguration(new BeerTypeConfig());
            //modelBuilder.ApplyConfiguration(new BreweryConfig());
            //modelBuilder.ApplyConfiguration(new UserConfig());
            //modelBuilder.ApplyConfiguration(new RoleConfig());
            //// modelBuilder.ApplyConfiguration(new UserRolesConfig());
            //modelBuilder.ApplyConfiguration(new UserBeersConfig());
            //modelBuilder.ApplyConfiguration(new ReviewConfig());
            //modelBuilder.ApplyConfiguration(new RateReviewConfig());

            //Seeder.Seeder.SeedDatabase(modelBuilder);

            //base.OnModelCreating(modelBuilder);

        }
    }
}
