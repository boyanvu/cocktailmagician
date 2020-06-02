using CocktailsMagician.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;


namespace CocktailsMagician.Data.Seeder
{
    public static class Seeder
    {
        public static void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new City()
                {
                    Id = Guid.Parse("68fee6bf-edd0-4121-8b06-37f0c7e11d4a"),
                    Name = "Sofia"
                },
                new City()
                {
                    Id = Guid.Parse("e3e92ad8-b117-42a8-b263-ec351d9234fc"),
                    Name = "Plovdiv"
                },
                new City()
                {
                    Id = Guid.Parse("cc44371d-594f-4c47-a82b-e606bede8d3b"),
                    Name = "Varna"
                },
                new City()
                {
                    Id = Guid.Parse("51d75009-3674-4a35-92f1-48a4981d26bb"),
                    Name = "Burgas"
                },
                new City()
                {
                    Id = Guid.Parse("50b800ab-bdec-48fa-8951-aaf2e2f19782"),
                    Name = "Veliko Tarnovo"
                });

            modelBuilder.Entity<Bar>().HasData(
                new Bar()
                {
                    Id = Guid.Parse("5fedc033-16db-4d62-b5e6-20eb3a056ead"),
                    Name = "Pavement",
                    Phone = "0877151152",
                    Website = "https://www.facebook.com/pages/%D0%91%D0%B0%D1%80-%D0%9F%D0%B0%D0%B2%D0%B0%D0%B6/662197613861829",
                    Description = @"Is incomparable pleasure to have a cup of coffee under the shade of linden trees and greenery of the park in close proximity to the coolness of the fountain. ",
                    CityId = Guid.Parse("68fee6bf-edd0-4121-8b06-37f0c7e11d4a"), // Sofia
                    Address = "at the corner of Angel Kanchev and Solunska"
                },
                new Bar()
                {
                    Id = Guid.Parse("e3be83dd-0c12-41d0-9f05-56554ad74a2d"),
                    Name = "Foket Bar",
                    Phone = "0888050505",
                    Website = "http://www.facebook.com/%D0%9A%D0%B0%D1%84%D0%B5-%D0%A4%D0%BE%D0%BA%D0%B5%D1%82-348364438530436/",
                    Description = "We chose the heart of Burgas, just a few steps away from the sea coast, to create the oasis of the pleasure for you. With the commercial music background we offer perfect conditions for the morning cup of coffee or the cocktail at sunset. ",
                    CityId = Guid.Parse("51d75009-3674-4a35-92f1-48a4981d26bb"), //Burgas
                    Address = "31 Morska Str."
                },
                new Bar()
                {
                    Id = Guid.Parse("92a05c62-6f33-4dc9-bcc1-c9c946bf693a"),
                    Name = "Pappa's Bar",
                    Phone = "0898878465",
                    Website = "-",
                    Description = "Very nice bar",
                    CityId = Guid.Parse("cc44371d-594f-4c47-a82b-e606bede8d3b"), //Varna
                    Address = "62 Prof. Marin Drinov Str."
                },
                new Bar()
                {
                    Id = Guid.Parse("1f573fa6-3cc0-48ad-8850-ee7675cc3096"),
                    Name = "Konyushnite",
                    Phone = "0899516116",
                    Website = "https://www.facebook.com/barkonushnite/",
                    Description = "Live music",
                    CityId = Guid.Parse("e3e92ad8-b117-42a8-b263-ec351d9234fc"), //Plovdiv
                    Address = "40 Saborna Str."
                });

            modelBuilder.Entity<Cocktail>().HasData(
                new Cocktail()
                {
                    Id = Guid.Parse("0961dd49-79f4-4d85-ab15-7844d602e076"),
                    Name = "Tom Collins",
                    Description = "Master this all-time gin classic. The Tom Collins is essentially a sparkling lemonade spiked with a healthy dose of the juniper-centric spirit. While there is a debate raging about which side of the pond this drink hails from, this cocktail lives up to its classic status with every sip."
                },
                new Cocktail()
                {
                    Id = Guid.Parse("9ef97551-87f6-40ce-a88b-6c0e876ccb51"),
                    Name = "Margarita",
                    Description = "The Margarita is one of the most popular cocktails in North America—for good reason. Combining the tang of lime and the sweetness of orange liqueur with the distinctive strength of tequila, our classic Margarita strikes all of the right keys."
                },
                new Cocktail()
                {
                    Id = Guid.Parse("96a5f42a-e14d-4cf6-834c-368f4e77076c"),
                    Name = "Dry Martini",
                    Description = "You could stumble down a very deep, very dark rabbit hole trying to determine who mixed the world’s first Martini. Was it a California prospector during the 1849 Gold Rush or the barman at a flossy New York City hotel 50 years later? Both stories hold water. Neither will leave you feeling as blissful and content as a well-made Dry Martini."
                },
                new Cocktail()
                {
                    Id = Guid.Parse("74d3f564-5811-4eda-97d6-e39d6bbd35a9"),
                    Name = "Cosmopolitan",
                    Description = "The legendary Cosmopolitan is a simple cocktail with a big history. It reached its height of popularity in the 1990s, when the HBO show “Sex and the City” was at its peak. The pink-hued Martini was a favorite of the characters on the show."
                },
                new Cocktail()
                {
                    Id = Guid.Parse("8a15e590-0b66-4fae-abfa-d75812b76da6"),
                    Name = "White Russian",
                    Description = "The White Russian is decadent and sophisticated. Combining vodka, Kahlúa and cream and serving it on the rocks create a delicious alternative to adult milkshakes. The Dude's favourite one."
                });

            modelBuilder.Entity<Role>().HasData(
                new Role()
                {
                    Id = Guid.Parse("1286919b-3fc1-484d-80ad-9aea8e55ac37"),
                    Name = "Admin",
                    NormalizedName = "admin",
                    ConcurrencyStamp = "c56fc50a-5f68-4e7d-838b-dc064a59ea09",
                    Description = "Admin role"
                },
                new Role()
                {
                    Id = Guid.Parse("f4fd169e-b855-496a-8d76-8c7720b60f46"),
                    Name = "User",
                    NormalizedName = "user",
                    ConcurrencyStamp = "d921ef64-4fb3-4f8a-83e7-e9d3b3fb41dd",
                    Description = "User role"
                });

            modelBuilder.Entity<IngredientType>().HasData(
                new IngredientType()
                {
                    Id = Guid.Parse("3c93e448-aa7f-40f9-b66f-fdf98b66053c"),
                    Name = "Vodka"
                },
                new IngredientType()
                {
                    Id = Guid.Parse("2fd6a412-0117-4a62-a608-494e414c9c03"),
                    Name = "Whisky"
                },
                new IngredientType()
                {
                    Id = Guid.Parse("4a399308-dec0-4161-a679-18b4898c7e4b"),
                    Name = "Liqeur"
                },
                new IngredientType()
                {
                    Id = Guid.Parse("67ffa75b-d067-4d77-a98d-99e203f4ad45"),
                    Name = "Brendy"
                },
                new IngredientType()
                {
                    Id = Guid.Parse("90ec3674-7a5c-4e8f-9a5f-d3aeef5e6c2e"),
                    Name = "Tequila"
                },
                new IngredientType()
                {
                    Id = Guid.Parse("c237a265-dd68-4218-a6a4-4eb7465e512f"),
                    Name = "Vermouth"
                },
                new IngredientType()
                {
                    Id = Guid.Parse("24cd3f18-f0a8-4f66-bc5b-2108e099cf53"),
                    Name = "Gin"
                },
                new IngredientType()
                {
                    Id = Guid.Parse("d949ac47-e51f-4a05-823e-d14c652d94da"),
                    Name = "Cognac"
                },
                new IngredientType()
                {
                    Id = Guid.Parse("27309394-4ac3-4dc6-a81a-c8e147e378f0"),
                    Name = "Burbon"
                },
                new IngredientType()
                {
                    Id = Guid.Parse("619ac43c-075a-47be-befc-c68249054b85"),
                    Name = "Rum"
                },
                new IngredientType()
                {
                    Id = Guid.Parse("8ff6497e-800b-43ac-8f53-9492e38d60a1"),
                    Name = "Tonic"
                },
                new IngredientType()
                {
                    Id = Guid.Parse("265dcf12-bcfc-43d3-93a6-6c48c97d51bc"),
                    Name = "Juice"
                },
                new IngredientType()
                {
                    Id = Guid.Parse("62bfb206-9d01-41cc-be6b-161faf95de55"),
                    Name = "Soda"
                },
                new IngredientType()
                {
                    Id = Guid.Parse("d45a9b74-04d4-4584-a25f-78a8692bbc31"),
                    Name = "Cola"
                },
                new IngredientType()
                {
                    Id = Guid.Parse("a13131de-cef0-4e94-9742-b698fa911de3"),
                    Name = "Fruit"
                },
                new IngredientType()
                {
                    Id = Guid.Parse("1b98e50e-8314-4b1e-82df-491c3c8d086f"),
                    Name = "Herbs"
                },
                new IngredientType()
                {
                    Id = Guid.Parse("8f799a3d-47cb-40e3-aeb4-a9fe80811360"),
                    Name = "Wine"
                },
                new IngredientType()
                {
                    Id = Guid.Parse("4039e0f3-8d2d-43a5-a82b-477e42371cd6"),
                    Name = "Others"
                },
                new IngredientType()
                {
                    Id = Guid.Parse("b54d35b5-1a1e-4da8-af73-46814ecdf240"),
                    Name = "Cream"
                },
                new IngredientType()
                {
                    Id = Guid.Parse("e393a0e6-c687-40e6-a0f1-e38032dfb693"),
                    Name = "Bitter"
                });

            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient()
                {
                    Id = Guid.Parse("1b98e50e-8314-4b1e-82df-491c3c8d086f"),
                    Name = "Gin",
                    Abv = 40,
                    Description = "Gin is a distilled alcoholic drink that derives its predominant flavour from juniper berries (Juniperus communis). Gin is one of the broadest categories of spirits, all of various origins, styles, and flavour profiles, that revolve around juniper as a common ingredient.",
                    TypeId = Guid.Parse("24cd3f18-f0a8-4f66-bc5b-2108e099cf53"),
                },
                new Ingredient()
                {
                    Id = Guid.Parse("8f799a3d-47cb-40e3-aeb4-a9fe80811360"),
                    Name = "Whisky",
                    Abv = 40,
                    Description = "Whisky or whiskey is a type of distilled alcoholic beverage made from fermented grain mash. Various grains (which may be malted) are used for different varieties, including barley, corn, rye, and wheat. Whisky is typically aged in wooden casks, generally made of charred white oak.",
                    TypeId = Guid.Parse("2fd6a412-0117-4a62-a608-494e414c9c03"),
                },
                new Ingredient()
                {
                    Id = Guid.Parse("4039e0f3-8d2d-43a5-a82b-477e42371cd6"),
                    Name = "Martini Extra Dry",
                    Abv = 0,
                    Description = "",
                    TypeId = Guid.Parse("c237a265-dd68-4218-a6a4-4eb7465e512f"),
                },
                new Ingredient()
                {
                    Id = Guid.Parse("9d4efae0-c48a-4b65-908a-6597658be6f8"),
                    Name = "Martini Dry",
                    Abv = 0,
                    Description = "",
                    TypeId = Guid.Parse("c237a265-dd68-4218-a6a4-4eb7465e512f"),
                },
                new Ingredient()
                {
                    Id = Guid.Parse("7d4c332d-c016-4594-9a46-4e1b0cd22955"),
                    Name = "Orange juice",
                    Abv = 0,
                    Description = "",
                    TypeId = Guid.Parse("265dcf12-bcfc-43d3-93a6-6c48c97d51bc"),
                },
                new Ingredient()
                {
                    Id = Guid.Parse("b91ed0c3-b009-4c83-993e-9acc4b0e384f"),
                    Name = "Peppermint",
                    Abv = 0,
                    Description = "-",
                    TypeId = Guid.Parse("1b98e50e-8314-4b1e-82df-491c3c8d086f"),
                },
                new Ingredient()
                {
                    Id = Guid.Parse("829f36d4-1ac9-438c-a653-964890eeff58"),
                    Name = "Kahlua",
                    Abv = 20,
                    Description = "Kahlua is a coffee-flavored liqueur from Mexico. The drink contains rum, sugar, vanilla bean, and arabica coffee.",
                    TypeId = Guid.Parse("4a399308-dec0-4161-a679-18b4898c7e4b"),
                },
                new Ingredient()
                {
                    Id = Guid.Parse("e89fd1c6-532e-42e0-8024-a2ff9c600006"),
                    Name = "Tequila",
                    Abv = 40,
                    Description = "Tequila is a distilled beverage made from the blue agave plant, primarily in the area surrounding the city of Tequila 65 km (40 mi) northwest of Guadalajara",
                    TypeId = Guid.Parse("90ec3674-7a5c-4e8f-9a5f-d3aeef5e6c2e"),
                },
                new Ingredient()
                {
                    Id = Guid.Parse("c5651f9b-a02c-4a87-9be0-cddf9ce07b98"),
                    Name = "Vodka",
                    Abv = 40,
                    Description = "Vodka is a clear distilled alcoholic beverage with different varieties originating in Poland and Russia. It is composed primarily of water and ethanol, but sometimes with traces of impurities and flavorings. Traditionally it is made by distilling the liquid from potatoes or cereal grains that have been fermented, though some modern brands use fruits or sugar as the base.",
                    TypeId = Guid.Parse("3c93e448-aa7f-40f9-b66f-fdf98b66053c"),
                },
                new Ingredient()
                {
                    Id = Guid.Parse("e393a0e6-c687-40e6-a0f1-e38032dfb693"),
                    Name = "Heavy cream",
                    Abv = 0,
                    Description = "-",
                    TypeId = Guid.Parse("b54d35b5-1a1e-4da8-af73-46814ecdf240"),
                },
                new Ingredient()
                {
                    Id = Guid.Parse("d8b1f1e3-b6a7-4e6d-8abe-2aa1db4abbe4"),
                    Name = "Orange bitter",
                    Abv = 34,
                    Description = "Orange bitters is a form of bitters, a cocktail flavoring made from such ingredients as the peels of Seville oranges, cardamom, caraway seed, coriander, anise, and burnt sugar in an alcohol base.",
                    TypeId = Guid.Parse("e393a0e6-c687-40e6-a0f1-e38032dfb693"),
                },
                new Ingredient()
                {
                    Id = Guid.Parse("db3d1530-7f55-40c9-82dd-10428c8e8dcc"),
                    Name = "Lemon",
                    Abv = 0,
                    Description = "",
                    TypeId = Guid.Parse("a13131de-cef0-4e94-9742-b698fa911de3"),
                });

            var hasher = new PasswordHasher<User>();
            User admin1 = new User
            {
                Id = Guid.Parse("a137730d-bb81-4611-8fb8-bb777aae86ac"),
                UserName = "bvuchev@abv.bg",
                NormalizedUserName = "BVUCHEV@ABV.BG",
                FirstName = "Boyan",
                LastName = "Vuchev",
                Email = "bvuchev@abv.bg",
                NormalizedEmail = "BVUCHEV@ABV.BG",
                LockoutEnabled = true,
                SecurityStamp = "DC6E275DD1E24957A7781D42BB68293B",
            };
            admin1.PasswordHash = hasher.HashPassword(admin1, "123456");

            User user1 = new User
            {
                Id = Guid.Parse("ad513447-0536-432b-a848-ea96ade0040d"),
                UserName = "rsimeonov@abv.bg",
                NormalizedUserName = "RSIMEONOV@ABV.BG",
                FirstName = "Radoslav",
                LastName = "Simeonov",
                Email = "rsimeonov@abv.bg",
                NormalizedEmail = "RSIMEONOV@ABV.BG",
                LockoutEnabled = true,
                SecurityStamp = "HNWQ7GQFUMWKGOAWSJNC5XV2VFYQRWHC",
            };
            user1.PasswordHash = hasher.HashPassword(user1, "123456");

            modelBuilder.Entity<User>().HasData(admin1, user1);

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>
                {
                    RoleId = Guid.Parse("1286919b-3fc1-484d-80ad-9aea8e55ac37"), //Admin
                    UserId = Guid.Parse("a137730d-bb81-4611-8fb8-bb777aae86ac") //Boyan
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = Guid.Parse("f4fd169e-b855-496a-8d76-8c7720b60f46"), //User
                    UserId = Guid.Parse("ad513447-0536-432b-a848-ea96ade0040d") //Rado
                });

            modelBuilder.Entity<CocktailIngredients>().HasData(
                new CocktailIngredients()
                {
                    CocktailId = Guid.Parse("8a15e590-0b66-4fae-abfa-d75812b76da6"), //White russian
                    IngredientId = Guid.Parse("c5651f9b-a02c-4a87-9be0-cddf9ce07b98"), //Vodka
                },
                new CocktailIngredients()
                {
                    CocktailId = Guid.Parse("8a15e590-0b66-4fae-abfa-d75812b76da6"), //White russian
                    IngredientId = Guid.Parse("829f36d4-1ac9-438c-a653-964890eeff58"), //Kahlua
                },
                new CocktailIngredients()
                {
                    CocktailId = Guid.Parse("8a15e590-0b66-4fae-abfa-d75812b76da6"), //White russian
                    IngredientId = Guid.Parse("e393a0e6-c687-40e6-a0f1-e38032dfb693"), //Heavy cream
                },
                new CocktailIngredients()
                {
                    CocktailId = Guid.Parse("96a5f42a-e14d-4cf6-834c-368f4e77076c"), //Dry martini
                    IngredientId = Guid.Parse("d8b1f1e3-b6a7-4e6d-8abe-2aa1db4abbe4"), //Orange bitter
                },
                new CocktailIngredients()
                {
                    CocktailId = Guid.Parse("96a5f42a-e14d-4cf6-834c-368f4e77076c"), //Dry martini
                    IngredientId = Guid.Parse("9d4efae0-c48a-4b65-908a-6597658be6f8"), //Martini Dry
                },
                new CocktailIngredients()
                {
                    CocktailId = Guid.Parse("96a5f42a-e14d-4cf6-834c-368f4e77076c"), //Dry martini
                    IngredientId = Guid.Parse("db3d1530-7f55-40c9-82dd-10428c8e8dcc"), //Lemon
                },
                new CocktailIngredients()
                {
                    CocktailId = Guid.Parse("96a5f42a-e14d-4cf6-834c-368f4e77076c"), //Dry martini
                    IngredientId = Guid.Parse("1b98e50e-8314-4b1e-82df-491c3c8d086f"), //Gin
                });

            modelBuilder.Entity<BarReview>().HasData(
                new BarReview()
                {
                    Id = Guid.Parse("162a3202-b5d8-495a-a9d8-76b1974d3525"),
                    BarId = Guid.Parse("e3be83dd-0c12-41d0-9f05-56554ad74a2d"),
                    UserId = Guid.Parse("ad513447-0536-432b-a848-ea96ade0040d"), //Rado
                    Rating = 5,
                    Comment = "Very nice and cosy place",
                    ReviewedOn = DateTime.UtcNow
                },
                new BarReview()
                {
                    Id = Guid.Parse("d277aee1-8292-4d39-a347-77b9da349c54"),
                    BarId = Guid.Parse("1f573fa6-3cc0-48ad-8850-ee7675cc3096"),
                    UserId = Guid.Parse("ad513447-0536-432b-a848-ea96ade0040d"), //Rado
                    Rating = 3,
                    Comment = "Not bad",
                    ReviewedOn = DateTime.UtcNow
                },
                new BarReview()
                {
                    Id = Guid.Parse("5549a94f-081a-4491-a386-022bd3fe2c4b"),
                    BarId = Guid.Parse("e3be83dd-0c12-41d0-9f05-56554ad74a2d"),
                    UserId = Guid.Parse("a137730d-bb81-4611-8fb8-bb777aae86ac"), //Boyan
                    Rating = 2,
                    Comment = "It is fuckin hole",
                    ReviewedOn = DateTime.UtcNow
                },
                new BarReview()
                {
                    Id = Guid.Parse("2790a53d-b5ea-4ba6-a651-eb3e79f8db7f"),
                    BarId = Guid.Parse("1f573fa6-3cc0-48ad-8850-ee7675cc3096"),
                    UserId = Guid.Parse("a137730d-bb81-4611-8fb8-bb777aae86ac"), //Boyan
                    Rating = 5,
                    Comment = "Very nice place to drink and listen live music.",
                    ReviewedOn = DateTime.UtcNow
                });

            modelBuilder.Entity<BarReviewLike>().HasData(
                new BarReviewLike()
                {
                    BarReviewId = Guid.Parse("5549a94f-081a-4491-a386-022bd3fe2c4b"),
                    UserId = Guid.Parse("ad513447-0536-432b-a848-ea96ade0040d"), //Rado
                    IsInappropriate = true,
                },
                new BarReviewLike()
                {
                    BarReviewId = Guid.Parse("d277aee1-8292-4d39-a347-77b9da349c54"),
                    UserId = Guid.Parse("a137730d-bb81-4611-8fb8-bb777aae86ac"), //Boyan
                    IsLiked = true,
                });

            modelBuilder.Entity<CocktailReview>().HasData(
                new CocktailReview()
                {
                    Id = Guid.Parse("d7047a3a-7b5e-4eb5-8ed2-c846b7a4d5ce"),
                    CocktailId = Guid.Parse("9ef97551-87f6-40ce-a88b-6c0e876ccb51"), // Margarita
                    UserId = Guid.Parse("ad513447-0536-432b-a848-ea96ade0040d"), //Rado
                    Rating = 1,
                    Comment = "Too sour",
                    ReviewedOn = DateTime.UtcNow
                },
                new CocktailReview()
                {
                    Id = Guid.Parse("11c58b41-f0db-480d-bbe5-115bc027f868"),
                    CocktailId = Guid.Parse("0961dd49-79f4-4d85-ab15-7844d602e076"), // Tom Colins
                    UserId = Guid.Parse("ad513447-0536-432b-a848-ea96ade0040d"), //Rado
                    Rating = 1,
                    Comment = "Piece of shit",
                    ReviewedOn = DateTime.UtcNow
                },
                new CocktailReview()
                {
                    Id = Guid.Parse("febc5720-77ef-444b-b3fd-d440af2a9359"),
                    CocktailId = Guid.Parse("9ef97551-87f6-40ce-a88b-6c0e876ccb51"), //Margarita
                    UserId = Guid.Parse("a137730d-bb81-4611-8fb8-bb777aae86ac"), //Boyan
                    Rating = 5,
                    Comment = "Perfect for summer",
                    ReviewedOn = DateTime.UtcNow
                },
                new CocktailReview()
                {
                    Id = Guid.Parse("16e1a85a-1d0f-4c42-b7dc-64efc096eb51"),
                    CocktailId = Guid.Parse("0961dd49-79f4-4d85-ab15-7844d602e076"), // Tom Colins
                    UserId = Guid.Parse("a137730d-bb81-4611-8fb8-bb777aae86ac"), //Boyan
                    Rating = 3,
                    Comment = "Not bad.",
                    ReviewedOn = DateTime.UtcNow
                });

            modelBuilder.Entity<CocktailReviewLike>().HasData(
                new CocktailReviewLike()
                {
                    CocktailReviewId = Guid.Parse("11c58b41-f0db-480d-bbe5-115bc027f868"),
                    UserId = Guid.Parse("a137730d-bb81-4611-8fb8-bb777aae86ac"), //Boyan
                    IsInappropriate = true,
                },
                new CocktailReviewLike()
                {
                    CocktailReviewId = Guid.Parse("febc5720-77ef-444b-b3fd-d440af2a9359"),
                    UserId = Guid.Parse("a137730d-bb81-4611-8fb8-bb777aae86ac"), //Boyan
                    IsLiked = true,
                });
        }
    }
}
