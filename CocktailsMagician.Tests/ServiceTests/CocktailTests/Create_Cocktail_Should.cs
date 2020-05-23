using CocktailsMagician.Data;
using CocktailsMagician.Services;
using CocktailsMagician.Services.DTO_s;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailsMagician.Tests.ServiceTests.CocktailTests
{
    [TestClass]
    public class Create_Cocktail_Should
    {
        [TestMethod]
        public async Task Create_Correct_Cocktail()
        {
            var options = Utils.GetOptions(nameof(Create_Correct_Cocktail));

            using (var arrangeContext = new CMContext(options))
            {
                var sut = new CocktailService(arrangeContext);
                var cocktailDTO = await sut.CreateCocktail(
                     new CocktailDTO
                     {
                         Id = Guid.Parse("9ef97551-87f6-40ce-a88b-6c0e876ccb51"),
                         Name = "Margarita",
                         Description = "The Margarita is one of the most popular cocktails " +
                         "in North America—for good reason. Combining the tang of lime and " +
                         "the sweetness of orange liqueur with the distinctive strength of " +
                         "tequila, our classic Margarita strikes all of the right keys."
                     });
            }

            using (var assertContext = new CMContext(options))
            {
                Assert.AreEqual("Margarita", assertContext.Cocktails.First().Name);
            }
        }

        [TestMethod]
        public async Task Throw_Exception_When_Cocktail_IsNull()
        {
            var options = Utils.GetOptions(nameof(Throw_Exception_When_Cocktail_IsNull));

            using (var assertContext = new CMContext(options))
            {
                var sut = new CocktailService(assertContext);
                await Assert.ThrowsExceptionAsync<ArgumentNullException>
                    (async () => await sut.CreateCocktail(null));
            }
        }
    }
}

