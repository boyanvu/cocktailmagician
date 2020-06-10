using CocktailsMagician.Data;
using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace CocktailsMagician.Tests.ServiceTests.BarCocktailTests
{
    [TestClass]
    public class Is_Cocktail_Available_In_Bar_Should
    {
        [TestMethod]
        public async Task Return_True_If_Bar_Has_Cocktail()
        {
            var options = Utils.GetOptions(nameof(Return_True_If_Bar_Has_Cocktail));

            var bar = new Bar()
            {
                Id = Guid.Parse("1f573fa6-3cc0-48ad-8850-ee7675cc3096"),
                Name = "Konyushnite",
                Phone = "0899516116",
                Website = "-",
                Description = "Live music",
                CityId = Guid.Parse("e3e92ad8-b117-42a8-b263-ec351d9234fc"), 
                Address = "40 Saborna Str."
            };

            var cocktail = new Cocktail
            {
                Id = Guid.Parse("9ef97551-87f6-40ce-a88b-6c0e876ccb51"),
                Name = "Margarita",
                Description = "The Margarita is one of the most " +
                "popular cocktails in North America—for good reason. " +
                "Combining the tang of lime and the sweetness of o" +
                "range liqueur with the distinctive strength of " +
                "tequila, our classic Margarita strikes all of the right keys."
            };

            var barCocktail = new BarCocktail
            {
                CocktailId = cocktail.Id,
                BarId = bar.Id,
                UnlistedOn = null
            };

            using (var arrangeContext = new CMContext(options))
            {
                arrangeContext.Bars.Add(bar);
                arrangeContext.Cocktails.Add(cocktail);
                arrangeContext.BarCocktails.Add(barCocktail);

                arrangeContext.SaveChanges();
            }

            using (var assertContext = new CMContext(options))
            {
                var sut = new CocktailService(assertContext);
                var result = await sut.IsCocktailAvailableInBar(barCocktail.BarId, barCocktail.CocktailId);

                Assert.IsTrue(result);
            }
        }
    }
}
