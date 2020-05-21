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

namespace CocktailsMagician.Tests.ServiceTests.IngredientsTests
{
    [TestClass]
    public class Get_Ingredient_Should
    {
        [TestMethod]
        public async Task Get_Correct_Ingredient()
        {
            var options = Utils.GetOptions(nameof(Get_Correct_Ingredient));
            var ingredient = new Ingredient
            {
                Id = Guid.Parse("1b98e50e-8314-4b1e-82df-491c3c8d086f"),
                Name = "Gin",
                Abv = 40,
                Description = "Gin is a distilled alcoholic drink that derives its " +
                        "predominant flavour from juniper berries (Juniperus communis). " +
                        "Gin is one of the broadest categories of spirits, all of various origins, styles," +
                        " and flavour profiles, that revolve around juniper as a common ingredient.",
                TypeId = Guid.Parse("27309394-4ac3-4dc6-a81a-c8e147e378f0"),
                Type = new IngredientType()
                {
                    Id = Guid.Parse("27309394-4ac3-4dc6-a81a-c8e147e378f0"),
                    Name = "Burbon"
                },
            };

            using (var arrangeContext = new CMContext(options))
            {
                arrangeContext.Ingredients.Add(ingredient);
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new CMContext(options))
            {
                var sut = new IngredientService(assertContext);
                Guid resultGuid = new Guid("1b98e50e-8314-4b1e-82df-491c3c8d086f");
                var result = await sut.GetIngredient(resultGuid);
                Assert.AreEqual("Gin", result.Name);
                Assert.AreEqual(40, result.Abv);
                Assert.IsInstanceOfType(result, typeof(IngredientDTO));
            }
        }

        [TestMethod]
        public async Task Throw_When_GIngredientNotFound()
        {
            var options = Utils.GetOptions(nameof(Throw_When_GIngredientNotFound));

            using (var assertContext = new CMContext(options))
            {
                var sut = new IngredientService(assertContext);
                Guid resultGuid = new Guid("4039e0f3-8d2d-43a5-a82b-477e42371cd6");

                await Assert.ThrowsExceptionAsync<ArgumentNullException>
                    (async () => await sut.DeleteIngredient(resultGuid));
            }
        }
    }
}
