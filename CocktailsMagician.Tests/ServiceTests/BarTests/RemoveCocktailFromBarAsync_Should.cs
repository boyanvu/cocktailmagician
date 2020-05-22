using CocktailsMagician.Data;
using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services.DTO_s;
using CocktailsMagician.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailsMagician.Tests.ServiceTests.BarTests
{
    [TestClass]
    public class RemoveCocktailFromBarAsync_Should
    {
        [TestMethod]
        public async Task RemoveCocktailFromBarAsync_Correct()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(RemoveCocktailFromBarAsync_Correct));
            var barId = Guid.Parse("92a05c62-6f33-4dc9-bcc1-c9c946bf693a");
            var cocktailId = Guid.Parse("9ef97551-87f6-40ce-a88b-6c0e876ccb51");
            var dateUnlistedOn = new DateTime(2020, 05, 01);

            var bar = new Bar()
            {
                Id = barId,
                Name = "Just another bar",
                Phone = "0898878465",
                CityId = Guid.Parse("cc44371d-594f-4c47-a82b-e606bede8d3b"), //Varna
                Address = "62 Prof. Marin Drinov Str.",
            };
            var cocktail = new Cocktail()
            {
                Id = Guid.Parse("9ef97551-87f6-40ce-a88b-6c0e876ccb51"),
                Name = "Margarita",
            };
            var barCocktails = new BarCocktail()
            {
                BarId = barId,
                CocktailId = cocktailId,
                UnlistedOn = dateUnlistedOn
            };
            using (var arrangeContext = new CMContext(options))
            {
                arrangeContext.Bars.Add(bar);
                arrangeContext.Cocktails.Add(cocktail);
                arrangeContext.BarCocktails.Add(barCocktails);
                await arrangeContext.SaveChangesAsync();
            }
            //Act,Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarService(assertContext);
                var result1 = await sut.RemoveCocktailFromBarAsync(barId, cocktailId);
                var result2 = assertContext.BarCocktails.Where(bc => bc.BarId == barId && bc.CocktailId == cocktailId).FirstOrDefault();
                Assert.IsTrue(result1);
                Assert.AreEqual(dateUnlistedOn,result2.UnlistedOn);
            }
        }
    

        [TestMethod]
        public async Task Throw_When_Combination_IsMissing()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(Throw_When_Combination_IsMissing));
            var barId = Guid.Parse("92a05c62-6f33-4dc9-bcc1-c9c946bf693a");
            var cocktailId = Guid.Parse("9ef97551-87f6-40ce-a88b-6c0e876ccb51");

            //Act,Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarService(assertContext);
                await Assert.ThrowsExceptionAsync<ArgumentNullException>
                    (async () => await sut.RemoveCocktailFromBarAsync(barId, cocktailId));
            }
        }
    }
}

//public async Task<bool> RemoveCocktailFromBarAsync(Guid barId, Guid cocktailId)
//{
//    var barCocktail = await _cmContext.BarCocktails
//        .Where(bc => bc.BarId == barId && bc.CocktailId == cocktailId)
//        .FirstOrDefaultAsync(bc => bc.UnlistedOn == null);

//    if (barCocktail == null)
//    {
//        throw new ArgumentNullException("The specific bar-cocktail combination is unlisted or does not exist.");
//    }
//    else
//    {
//        barCocktail.UnlistedOn = DateTime.UtcNow;
//        try
//        {
//            await _cmContext.SaveChangesAsync();
//        }
//        catch (Exception)
//        {
//            throw;
//        }
//        return true;
//    }
//}