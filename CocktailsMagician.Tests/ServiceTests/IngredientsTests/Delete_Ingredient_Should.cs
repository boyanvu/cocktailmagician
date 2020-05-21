using CocktailsMagician.Data;
using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailsMagician.Tests.ServiceTests.IngredientsTests
{
    [TestClass]
    public class Delete_Ingredient_Should
    {
        [TestMethod]
        public async Task ReturnTrue_When_IngredientIsDeleted()
        {
            var options = Utils.GetOptions(nameof(ReturnTrue_When_IngredientIsDeleted));

            var ingredient = new Ingredient
            {
                Id = Guid.Parse("4039e0f3-8d2d-43a5-a82b-477e42371cd6"),
                Name = "Martini Extra Dry",
                Abv = 0,
                Description = "",
                TypeId = Guid.Parse("619ac43c-075a-47be-befc-c68249054b85"),
            };
            using (var arrangeContext = new CMContext(options))
            {
                arrangeContext.Ingredients.Add(ingredient);
                await arrangeContext.SaveChangesAsync();

            }
            using (var assertContext = new CMContext(options))
            {
                var sut = new IngredientService(assertContext);
                Guid resultGuid = new Guid("4039e0f3-8d2d-43a5-a82b-477e42371cd6");
                var result = await sut.DeleteIngredient(resultGuid);
                
                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public async Task Throw_When_IngredientNotFound()
        {
            var options = Utils.GetOptions(nameof(Throw_When_IngredientNotFound));

            using (var assertContext = new CMContext(options))
            {
                var sut = new IngredientService(assertContext);
                Guid resultGuid = new Guid("4039e0f3-8d2d-43a5-a82b-477e42371cd6");

                await Assert.ThrowsExceptionAsync<ArgumentNullException>
                    (async() => await sut.DeleteIngredient(resultGuid));
            }
        }

    }

}
