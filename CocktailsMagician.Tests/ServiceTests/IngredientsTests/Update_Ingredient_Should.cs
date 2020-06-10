using CocktailsMagician.Data;
using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace CocktailsMagician.Tests.ServiceTests.IngredientsTests
{
    [TestClass]
    public class Update_Ingredient_Should
    {
        [TestMethod]
        public async Task Return_Correct_Updated_Ingredient()
        {
            var options = Utils.GetOptions(nameof(Return_Correct_Updated_Ingredient));

            var ingredient = new Ingredient
            {
                Id = Guid.Parse("4039e0f3-8d2d-43a5-a82b-477e42371cd6"),
                Name = "Martini Extra Dry",
                Abv = 0,
                Description = "",
                TypeId = Guid.Parse("619ac43c-075a-47be-befc-c68249054b85"),
                Type = new IngredientType
                {
                    Id = Guid.Parse("619ac43c-075a-47be-befc-c68249054b85"),
                    Name = "Rum"
                }
            };

            var ingredientType = new IngredientType()
            {
                Id = Guid.Parse("4a399308-dec0-4161-a679-18b4898c7e4b"),
                Name = "Liqeur"
            };
            using (var arrangeContext = new CMContext(options))
            {
                arrangeContext.Ingredients.Add(ingredient);
                arrangeContext.IngredientTypes.Add(ingredientType);
                arrangeContext.SaveChanges();
            }

            var newName = "Water";
            var newAbv = 15;
            var newDescr = "Top";

            using (var assertContext = new CMContext(options))
            {
                var sut = new IngredientService(assertContext);
                var result = await sut.UpdateIngredient(ingredient.Id, newName, newAbv, newDescr, ingredientType.Id);

                Assert.AreEqual(ingredient.Id, result.Id);
                Assert.AreEqual(newName, result.Name);
                Assert.AreEqual(newDescr, result.Description);
                Assert.AreEqual(newAbv, result.Abv);
                Assert.AreEqual(ingredientType.Id, result.TypeId);
            }
        }


        [TestMethod]
        public async Task Throw_When_UpdIngredientNotFound()
        {
            var options = Utils.GetOptions(nameof(Throw_When_UpdIngredientNotFound));

            var newName = "Water";
            var newAbv = 15;
            var newDescr = "Top";


            using (var assertContext = new CMContext(options))
            {
                var sut = new IngredientService(assertContext);
                Guid ingrId = new Guid("4039e0f3-8d2d-43a5-a82b-477e42371cd6");
                Guid ingrTypeId = new Guid("619ac43c-075a-47be-befc-c68249054b85");

                await Assert.ThrowsExceptionAsync<ArgumentNullException>
                    (async () => await sut.UpdateIngredient(ingrId, newName, newAbv, newDescr, ingrTypeId));
            }
        }
    }
}
