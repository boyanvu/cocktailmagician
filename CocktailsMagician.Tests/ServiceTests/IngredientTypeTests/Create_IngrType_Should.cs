using CocktailsMagician.Data;
using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services;
using CocktailsMagician.Services.DTO_s;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailsMagician.Tests.ServiceTests.IngredientTypeTests
{
    [TestClass]
    public class Create_IngrType_Should
    {
        [TestMethod]
        public async Task Create_Correct_IngredientType()
        {
            var options = Utils.GetOptions(nameof(Create_Correct_IngredientType));

            using (var arrangeContext = new CMContext(options))
            {
                var sut = new IngredientTypeService(arrangeContext);
                var ingrTypeDTO = await sut.CreateIngredientType(
                     new IngredientTypeDTO()
                     {
                         Id = Guid.Parse("619ac43c-075a-47be-befc-c68249054b85"),
                         Name = "Rum"
                     });
            }

            using (var assertContext = new CMContext(options))
            {
                Assert.AreEqual("Rum", assertContext.IngredientTypes.First().Name);
            }

        }

        [TestMethod]
        public async Task Throw_Exception_When_IngredientType_IsNull()
        {
            var options = Utils.GetOptions(nameof(Throw_Exception_When_IngredientType_IsNull));

            using (var assertContext = new CMContext(options))
            {
                var sut = new IngredientTypeService(assertContext);
                await Assert.ThrowsExceptionAsync<ArgumentNullException>
                    (async () => await sut.CreateIngredientType(null));
            }
        }
    }
}
