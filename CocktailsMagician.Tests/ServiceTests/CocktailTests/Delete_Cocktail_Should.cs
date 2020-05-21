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
    public class Delete_Cocktail_Should
    {
        [TestMethod]
        public async Task ReturnTrue_When_CocktailIsDeleted()
        {
            var options = Utils.GetOptions(nameof(ReturnTrue_When_CocktailIsDeleted));

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

            using (var arrangeContext = new CMContext(options))
            {
                arrangeContext.Cocktails.Add(cocktail);
                await arrangeContext.SaveChangesAsync();

            }
            using (var assertContext = new CMContext(options))
            {
                var sut = new CocktailService(assertContext);
                Guid resultGuid = new Guid("9ef97551-87f6-40ce-a88b-6c0e876ccb51");
                var result = await sut.DeleteCocktail(resultGuid);

                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public async Task Throw_When_DCocktailNotFound()
        {
            var options = Utils.GetOptions(nameof(Throw_When_DCocktailNotFound));

            using (var assertContext = new CMContext(options))
            {
                var sut = new CocktailService(assertContext);
                Guid resultGuid = new Guid("4039e0f3-8d2d-43a5-a82b-477e42371cd6");

                await Assert.ThrowsExceptionAsync<ArgumentNullException>
                    (async () => await sut.DeleteCocktail(resultGuid));
            }
        }
    }
}
