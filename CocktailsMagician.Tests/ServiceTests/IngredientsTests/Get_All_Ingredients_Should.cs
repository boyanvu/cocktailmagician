using CocktailsMagician.Data;
using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace CocktailsMagician.Tests.ServiceTests.IngredientsTests
{
    [TestClass]
    public class Get_All_Ingredients_Should
    {
        [TestMethod]
        public async Task Get_Correct_Number_Ingredients()
        {
            var options = Utils.GetOptions(nameof(Get_Correct_Number_Ingredients));
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

            var ingredient2 = new Ingredient
            {
                Id = Guid.Parse("4039e0f3-8d2d-43a5-a82b-477e42371cd6"),
                Name = "Martini Extra Dry",
                Abv = 0,
                Description = "",
                TypeId = Guid.Parse("619ac43c-075a-47be-befc-c68249054b85"),
                Type = new IngredientType()
                {
                    Id = Guid.Parse("619ac43c-075a-47be-befc-c68249054b85"),
                    Name = "Rum"
                },
            };

            using (var arrangeContext = new CMContext(options))
            {
                arrangeContext.Ingredients.Add(ingredient);
                arrangeContext.Ingredients.Add(ingredient2);
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new CMContext(options))
            {
                var sut = new IngredientService(assertContext);
                var result = await sut.GetAllIngredients();
                Assert.AreEqual("Gin", result.ElementAt(0).Name);
                Assert.AreEqual("Martini Extra Dry", result.ElementAt(1).Name);
            }
        }
    }
}
