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
    public class Add_CReview_Like_Should
    {
        [TestMethod]
        public async Task Add_Cocktail_Review_Like()
        {
            var options = Utils.GetOptions(nameof(Add_Cocktail_Review_Like));

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
                var sut = new CocktailReviewLikeService(arrangeContext);

                arrangeContext.Cocktails.Add(cocktail);
                arrangeContext.Users.Add(user);
                arrangeContext.CocktailReviews.Add(cReview);
                await arrangeContext.SaveChangesAsync();
                await sut.AddCocktailReviewLike(cReview.Id, user.UserName);
            }

            using (var assertContext = new CMContext(options))
            {
                Assert.AreEqual(cReview.Id, assertContext.CocktailReviewLikes.First().CocktailReviewId);
                Assert.AreEqual(user.Id, assertContext.CocktailReviewLikes.First().UserId);

            }
        }

        [TestMethod]
        public async Task Change_Cocktail_Review_Like_True()
        {
            var options = Utils.GetOptions(nameof(Change_Cocktail_Review_Like_True));

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

            var cReviewLike = new CocktailReviewLike
            {
                UserId = user.Id,
                CocktailReviewId = cReview.Id,
                IsLiked = false
            };

            using (var arrangeContext = new CMContext(options))
            {
                var sut = new CocktailReviewLikeService(arrangeContext);

                arrangeContext.Cocktails.Add(cocktail);
                arrangeContext.Users.Add(user);
                arrangeContext.CocktailReviews.Add(cReview);
                arrangeContext.CocktailReviewLikes.Add(cReviewLike);
                await arrangeContext.SaveChangesAsync();

                await sut.AddCocktailReviewLike(cReview.Id, user.UserName);
            }

            using (var assertContext = new CMContext(options))
            {
                Assert.AreEqual(cReview.Id, assertContext.CocktailReviewLikes.First().CocktailReviewId);
                Assert.AreEqual(user.Id, assertContext.CocktailReviewLikes.First().UserId);
                Assert.AreEqual(true, assertContext.CocktailReviewLikes.First().IsLiked);
            }
        }


        [TestMethod]
        public async Task Throw_When_CRL_CR_IsNull()
        {
            var options = Utils.GetOptions(nameof(Throw_When_CRL_CR_IsNull));

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


            var crId = Guid.Parse("d7047a3a-7b5e-4eb5-8ed2-c846b7a4d5ce");
         

            using (var arrangeContext = new CMContext(options))
            {
                var sut = new CocktailReviewLikeService(arrangeContext);

                arrangeContext.Cocktails.Add(cocktail);
                arrangeContext.Users.Add(user);
                await arrangeContext.SaveChangesAsync();

            }

            using (var assertContext = new CMContext(options))
            {
                var sut = new CocktailReviewLikeService(assertContext);
                await Assert.ThrowsExceptionAsync<ArgumentNullException>
                    (async () => await sut.AddCocktailReviewLike(crId, user.UserName));
            }
        }


        [TestMethod]
        public async Task Throw_When_CRL_User_IsNull()
        {
            var options = Utils.GetOptions(nameof(Throw_When_CRL_User_IsNull));

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
                var sut = new CocktailReviewLikeService(arrangeContext);

                arrangeContext.Cocktails.Add(cocktail);
                arrangeContext.Users.Add(user);
                arrangeContext.CocktailReviews.Add(cReview);
                await arrangeContext.SaveChangesAsync();

            }

            using (var assertContext = new CMContext(options))
            {
                var sut = new CocktailReviewLikeService(assertContext);
                await Assert.ThrowsExceptionAsync<ArgumentNullException>
                    (async () => await sut.AddCocktailReviewLike(cReview.Id, "Pesho"));
            }
        }
    }
}
