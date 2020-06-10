using CocktailsMagician.Data;
using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace CocktailsMagician.Tests.ServiceTests.CocktailTests
{
    [TestClass]
    public class Get_All_Coktails_Should
    {
        [TestMethod]
        public async Task GetAllCocktails_Correct()
        {
            var options = Utils.GetOptions(nameof(GetAllCocktails_Correct));

            var cocktail = new Cocktail()
            {
                Id = Guid.Parse("9ef97551-87f6-40ce-a88b-6c0e876ccb51"),
                Name = "Margarita",
                Description = "The Margarita is one of the most " +
              "popular cocktails in North America—for good reason. " +
              "Combining the tang of lime and the sweetness of o" +
              "range liqueur with the distinctive strength of " +
              "tequila, our classic Margarita strikes all of the right keys."
            };

            var cocktail2 = new Cocktail()
            {
                Id = Guid.Parse("8a15e590-0b66-4fae-abfa-d75812b76da6"),
                Name = "White Russian",
                Description = "The White Russian is decadent and sophisticated. " +
                "Combining vodka, Kahlúa and cream and serving it on the " +
                "rocks create a delicious alternative to adult milkshakes. The Dude's favourite one."
            };

            using (var arrangeContext = new CMContext(options))
            {
                arrangeContext.Cocktails.Add(cocktail);
                arrangeContext.Cocktails.Add(cocktail2);
                await arrangeContext.SaveChangesAsync();
            }
            //Act,Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new CocktailService(assertContext);
                var result = await sut.GetAllCocktails();
                Assert.AreEqual(2, result.Count);            
            }
        }
    }
}
