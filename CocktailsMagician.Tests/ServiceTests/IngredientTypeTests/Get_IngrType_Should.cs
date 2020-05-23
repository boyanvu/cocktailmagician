using CocktailsMagician.Data;
using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services;
using CocktailsMagician.Services.DTO_s;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailsMagician.Tests.ServiceTests.IngredientTypeTests
{
    [TestClass]
    public class Get_IngrType_Should
    {
        [TestMethod]
        public async Task Get_Correct_IngredientType()
        {
            var options = Utils.GetOptions(nameof(Get_Correct_IngredientType));
            var ingredientType = new IngredientType
            {
                Id = Guid.Parse("619ac43c-075a-47be-befc-c68249054b85"),
                Name = "Rum"
            };

            using (var arrangeContext = new CMContext(options))
            {
                arrangeContext.IngredientTypes.Add(ingredientType);
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new CMContext(options))
            {
                var sut = new IngredientTypeService(assertContext);
                Guid resultGuid = new Guid("619ac43c-075a-47be-befc-c68249054b85");
                var result = await sut.GetIngredientType(resultGuid);
                Assert.AreEqual("Rum", result.Name);
                Assert.IsInstanceOfType(result, typeof(IngredientTypeDTO));
            }
        }


        [TestMethod]
        public async Task Throw_When_GIngredientTypeNotFound()
        {
            var options = Utils.GetOptions(nameof(Throw_When_GIngredientTypeNotFound));

            using (var assertContext = new CMContext(options))
            {
                var sut = new IngredientTypeService(assertContext);
                Guid resultGuid = new Guid("4039e0f3-8d2d-43a5-a82b-477e42371cd6");

                await Assert.ThrowsExceptionAsync<ArgumentNullException>
                    (async () => await sut.DeleteIngredientType(resultGuid));
            }
        }
    }
}
