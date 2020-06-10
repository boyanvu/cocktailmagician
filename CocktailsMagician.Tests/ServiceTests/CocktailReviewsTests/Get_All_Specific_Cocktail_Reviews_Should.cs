using CocktailsMagician.Data;
using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailsMagician.Tests.ServiceTests.CocktailReviewsTests
{
    [TestClass]
    public class Get_All_Specific_Cocktail_Reviews_Should
    {
        [TestMethod]
        public async Task Get_Correct_Number_CR()
        {
            var options = Utils.GetOptions(nameof(Get_Correct_Number_CR));

            var cocktail = new Cocktail()
            {
                Id = Guid.Parse("8a15e590-0b66-4fae-abfa-d75812b76da6"),
                Name = "White Russian",
                Description = "The White Russian is decadent and sophisticated."
            };

            var hasher = new PasswordHasher<User>();
            User user1 = new User
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
            user1.PasswordHash = hasher.HashPassword(user1, "123456");

            User user2 = new User
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
            user2.PasswordHash = hasher.HashPassword(user2, "123456");

            var cReview = new CocktailReview()
            {
                Id = Guid.Parse("d7047a3a-7b5e-4eb5-8ed2-c846b7a4d5ce"),
                CocktailId = cocktail.Id,
                UserId = user1.Id,
                Rating = 1,
                Comment = "Too sour",
                ReviewedOn = DateTime.UtcNow
            };

            var cReview2 = new CocktailReview()
            {
                Id = Guid.Parse("11c58b41-f0db-480d-bbe5-115bc027f868"),
                CocktailId = cocktail.Id,
                UserId = user2.Id,
                Rating = 5,
                Comment = "Great",
                ReviewedOn = DateTime.UtcNow
            };

            using (var arrangeContext = new CMContext(options))
            {
                arrangeContext.Cocktails.Add(cocktail);
                arrangeContext.Users.Add(user1);
                arrangeContext.Users.Add(user2);
                arrangeContext.CocktailReviews.Add(cReview);
                arrangeContext.CocktailReviews.Add(cReview2);
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new CMContext(options))
            {
                var sut = new CocktailReviewService(assertContext);
                var result = await sut.GetAllSpecificCocktailReviews(cocktail.Id);
                Assert.AreEqual(cReview.Id, result.ElementAt(0).Id);
                Assert.AreEqual(cReview2.Id, result.ElementAt(1).Id);
                Assert.AreEqual(cReview.UserId, result.ElementAt(0).UserId);
                Assert.AreEqual(cReview2.UserId, result.ElementAt(1).UserId);
                Assert.AreEqual(cReview.Comment, result.ElementAt(0).Comment);
                Assert.AreEqual(cReview2.Comment, result.ElementAt(1).Comment);
                Assert.AreEqual(2, result.Count());
            }

        }
    }
}
