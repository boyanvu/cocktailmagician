using CocktailsMagician.Data;
using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace CocktailsMagician.Tests.ServiceTests.IngredientTypeTests
{
    [TestClass]
    public class Update_IngrType_Should
    {
        [TestMethod]
        public async Task Return_Correct_Updated_IngredientType()
        {
            var options = Utils.GetOptions(nameof(Return_Correct_Updated_IngredientType));

            var ingredientType = new IngredientType()
            {
                Id = Guid.Parse("4a399308-dec0-4161-a679-18b4898c7e4b"),
                Name = "Liqeur"
            };

            using (var arrangeContext = new CMContext(options))
            {
                arrangeContext.IngredientTypes.Add(ingredientType);
                arrangeContext.SaveChanges();
            }

            var newName = "Liqeurr";

            using (var assertContext = new CMContext(options))
            {
                var sut = new IngredientTypeService(assertContext);
                var result = await sut.UpdateIngredientType(ingredientType.Id, newName);

                Assert.AreEqual(ingredientType.Id, result.Id);
                Assert.AreEqual(newName, result.Name);
            }
        }


        [TestMethod]
        public async Task Throw_When_UpdIngredientTypeNotFound()
        {
            var options = Utils.GetOptions(nameof(Throw_When_UpdIngredientTypeNotFound));

            var newName = "Liqeurr";

            using (var assertContext = new CMContext(options))
            {
                var sut = new IngredientTypeService(assertContext);
                Guid ingrId = new Guid("4039e0f3-8d2d-43a5-a82b-477e42371cd6");

                await Assert.ThrowsExceptionAsync<ArgumentNullException>
                    (async () => await sut.UpdateIngredientType(ingrId, newName));
            }
        }
    }
}
