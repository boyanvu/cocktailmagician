using CocktailsMagician.Data;
using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailsMagician.Tests.ServiceTests.CocktailTests
{
    [TestClass]
    public class Get_All_Cocktails_ForHM_Should
    {
        [TestMethod]
        public async Task GetAllCocktails_ForHM_Correct()
        {
            var options = Utils.GetOptions(nameof(GetAllCocktails_ForHM_Correct));

            var cocktail = new Cocktail()
            {
                Id = Guid.Parse("9ef97551-87f6-40ce-a88b-6c0e876ccb51"),
                Name = "Margarita",
                Description = "The Margarita is one of the most " +
              "popular cocktails in North America—for good reason. " +
              "Combining the tang of lime and the sweetness of o" +
              "range liqueur with the distinctive strength of " +
              "tequila, our classic Margarita strikes all of the right keys.",
                AvgRating = 5
            };

            var cocktail2 = new Cocktail()
            {
                Id = Guid.Parse("8a15e590-0b66-4fae-abfa-d75812b76da6"),
                Name = "White Russian",
                Description = "The White Russian is decadent and sophisticated. " +
                "Combining vodka, Kahlúa and cream and serving it on the " +
                "rocks create a delicious alternative to adult milkshakes. The Dude's favourite one.",
                AvgRating = 4,
            };

            var cocktail3 = new Cocktail()
            {
                Id = Guid.Parse("96a5f42a-e14d-4cf6-834c-368f4e77076c"),
                Name = "Dry Martini",
                Description = "You could stumble down a very deep, very dark rabbit hole trying to determine who mixed the world’s first Martini. Was it a California prospector during the 1849 Gold Rush or the barman at a flossy New York City hotel 50 years later? Both stories hold water. Neither will leave you feeling as blissful and content as a well-made Dry Martini.",
                AvgRating = 4
            };
            var cocktail4 = new Cocktail()
            {
                Id = Guid.Parse("74d3f564-5811-4eda-97d6-e39d6bbd35a9"),
                Name = "Cosmopolitan",
                Description = "The legendary Cosmopolitan is a simple cocktail with a big history. It reached its height of popularity in the 1990s, when the HBO show “Sex and the City” was at its peak. The pink-hued Martini was a favorite of the characters on the show.",
                AvgRating = 3
            };

            using (var arrangeContext = new CMContext(options))
            {
                arrangeContext.Cocktails.Add(cocktail);
                arrangeContext.Cocktails.Add(cocktail2);
                arrangeContext.Cocktails.Add(cocktail3);
                arrangeContext.Cocktails.Add(cocktail4);
                await arrangeContext.SaveChangesAsync();
            }
            //Act,Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new CocktailService(assertContext);
                var result = await sut.GetAllCocktailsForHomePage();
                Assert.AreEqual(cocktail.Id, result[0].Id);
                Assert.AreEqual(cocktail.Name, result[0].Name);
                Assert.AreEqual(3, result.Count);
            }
        }
    }
}
