using CocktailsMagician.Data;
using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailsMagician.Tests.ServiceTests.CocktailReviewsTests
{
    [TestClass]
    public class Has_Already_Reviewed_Should
    {
        [TestMethod]
        public async Task Return_Correct_If_Reviewd()
        {
            var options = Utils.GetOptions(nameof(Return_Correct_If_Reviewd));

            var cocktail = new Cocktail()
            {
                Id = Guid.Parse("74d3f564-5811-4eda-97d6-e39d6bbd35a9"),
                Name = "Cosmopolitan",
                Description = "The legendary Cosmopolitan is a simple cocktail with a big history."
            };

            var hasher = new PasswordHasher<User>();
            var user = new User
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
            user.PasswordHash = hasher.HashPassword(user, "123456");


            var cReview = new CocktailReview()
            {
                Id = Guid.Parse("d7047a3a-7b5e-4eb5-8ed2-c846b7a4d5ce"),
                CocktailId = cocktail.Id,
                UserId = user.Id,
                Rating = 1,
                Comment = "Too sour",
                ReviewedOn = DateTime.UtcNow
            };

            using (var arrangeContext = new CMContext(options))
            {
                arrangeContext.Cocktails.Add(cocktail);
                arrangeContext.Users.Add(user);
                arrangeContext.CocktailReviews.Add(cReview);
                await arrangeContext.SaveChangesAsync();
            }
               
            using (var assertContext = new CMContext(options))
            {
                var sut = new CocktailReviewService(assertContext);
                var result = await sut.HasAlreadyReviewedAsync(cocktail.Id, user.Id);
               
                Assert.AreEqual(true, result);
            }
        }
    }
}
