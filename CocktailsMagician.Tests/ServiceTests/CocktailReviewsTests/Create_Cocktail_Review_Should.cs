using CocktailsMagician.Data;
using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailsMagician.Tests.ServiceTests.CocktailReviewsTests
{
    [TestClass]
    public class Create_Cocktail_Review_Should
    {
        [TestMethod]
        public async Task Create_Cocktail_Review()
        {
            var options = Utils.GetOptions(nameof(Create_Cocktail_Review));

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

            using (var arrangeContext = new CMContext(options))
            {
                var sut = new CocktailReviewService(arrangeContext);

                arrangeContext.Cocktails.Add(cocktail);
                arrangeContext.Users.Add(user);
                await arrangeContext.SaveChangesAsync();

                var cocktailReviewDTO = await sut.CreateCocktailReview(cocktail.Name, user.UserName, 5, "Very good!");                  
            }

            using (var assertContext = new CMContext(options))
            {
                Assert.AreEqual(cocktail.Id, assertContext.CocktailReviews.First().CocktailId);
                Assert.AreEqual(user.Id, assertContext.CocktailReviews.First().UserId);
                Assert.AreEqual("Very good!", assertContext.CocktailReviews.First().Comment);
                Assert.AreEqual(5, assertContext.CocktailReviews.First().Rating);
            }
        }


        [TestMethod]
        public async Task Throw_Exception_When_CocktailReview_User_IsNull()
        {
            var options = Utils.GetOptions(nameof(Throw_Exception_When_CocktailReview_User_IsNull));

            var cocktail = new Cocktail()
            {
                Id = Guid.Parse("74d3f564-5811-4eda-97d6-e39d6bbd35a9"),
                Name = "Cosmopolitan",
                Description = "The legendary Cosmopolitan is a simple cocktail with a big history."
            };

            using (var arrangeContext = new CMContext(options))
            {
                var sut = new CocktailReviewService(arrangeContext);

                arrangeContext.Cocktails.Add(cocktail);
                await arrangeContext.SaveChangesAsync();
            }
            using (var assertContext = new CMContext(options))
            {
                var sut = new CocktailReviewService(assertContext);
                await Assert.ThrowsExceptionAsync<ArgumentNullException>
                    (async () => await sut.CreateCocktailReview(cocktail.Name, null, 5, "Very good!")); 
            }
        }


        [TestMethod]
        public async Task Throw_Exception_When_CocktailReview_Cocktail_IsNull()
        {
            var options = Utils.GetOptions(nameof(Throw_Exception_When_CocktailReview_Cocktail_IsNull));

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

            using (var arrangeContext = new CMContext(options))
            {
                var sut = new CocktailReviewService(arrangeContext);

                arrangeContext.Users.Add(user);
                await arrangeContext.SaveChangesAsync();
            }
            using (var assertContext = new CMContext(options))
            {
                var sut = new CocktailReviewService(assertContext);
                await Assert.ThrowsExceptionAsync<ArgumentNullException>
                    (async () => await sut.CreateCocktailReview(null, user.UserName, 5, "Very good!"));
            }
        }

        [TestMethod]
        public async Task Throw_Exception_When_CocktailReview_Rating_IsOutOfRange()
        {
            var options = Utils.GetOptions(nameof(Throw_Exception_When_CocktailReview_Rating_IsOutOfRange));

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

            using (var arrangeContext = new CMContext(options))
            {
                var sut = new CocktailReviewService(arrangeContext);

                arrangeContext.Users.Add(user);
                arrangeContext.Cocktails.Add(cocktail);
                await arrangeContext.SaveChangesAsync();
            }
            using (var assertContext = new CMContext(options))
            {
                var sut = new CocktailReviewService(assertContext);
                await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>
                    (async () => await sut.CreateCocktailReview(cocktail.Name, user.UserName, 15, "Very good!"));
            }
        }
    }
}
