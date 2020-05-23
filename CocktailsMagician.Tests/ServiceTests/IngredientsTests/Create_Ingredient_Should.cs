using CocktailsMagician.Data;
using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services;
using CocktailsMagician.Services.DTO_s;
using CocktailsMagician.Services.Mappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailsMagician.Tests.ServiceTests.IngredientsTests
{
    [TestClass]
    public class Create_Ingredient_Should
    {
        [TestMethod]
        public async Task Create_Correct_Ingredient()
        {
            var options = Utils.GetOptions(nameof(Create_Correct_Ingredient));
           
            using (var arrangeContext = new CMContext(options))
            {
                var sut = new IngredientService(arrangeContext);
                var ingredientDTO = await sut.CreateIngredient(
                     new IngredientDTO
                     {
                         Id = Guid.Parse("1b98e50e-8314-4b1e-82df-491c3c8d086f"),
                         Name = "Gin",
                         Abv = 40,
                         Description = "Gin is a distilled alcoholic drink that derives its " +
                        "predominant flavour from juniper berries (Juniperus communis). " +
                        "Gin is one of the broadest categories of spirits, all of various origins, styles," +
                        " and flavour profiles, that revolve around juniper as a common ingredient.",
                         TypeId = Guid.Parse("24cd3f18-f0a8-4f66-bc5b-2108e099cf53"),

                     });
            }

            using (var assertContext = new CMContext(options))
            {
                 Assert.AreEqual("Gin", assertContext.Ingredients.First().Name);
            }
        }


        [TestMethod]
        public async Task Throw_Exception_When_Ingredient_IsNull()
        {
            var options = Utils.GetOptions(nameof(Throw_Exception_When_Ingredient_IsNull));

            using (var assertContext = new CMContext(options))
            {
                var sut = new IngredientService(assertContext);
                await Assert.ThrowsExceptionAsync<ArgumentNullException>
                    (async () => await sut.CreateIngredient(null));
            }
        }
    }
}
