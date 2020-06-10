using CocktailsMagician.Data;
using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailsMagician.Tests.ServiceTests.CocktailIngredientsTests
{
    [TestClass]
    public class Get_All_CI_Should
    {
        [TestMethod]
        public async Task Return_Correct_Number_CocktailIngredients()
        {
            var options = Utils.GetOptions(nameof(Return_Correct_Number_CocktailIngredients));

            var ingredient = new Ingredient
            {
                Id = Guid.Parse("4039e0f3-8d2d-43a5-a82b-477e42371cd6"),
                Name = "Martini Extra Dry",
                Abv = 0,
                Description = "",
                TypeId = Guid.Parse("619ac43c-075a-47be-befc-c68249054b85"),
            };

            var ingredient2 = new Ingredient()
            {
                Id = Guid.Parse("1b98e50e-8314-4b1e-82df-491c3c8d086f"),
                Name = "Gin",
                Abv = 40,
                Description = "Gin is a distilled alcoholic drink that derives its predominant flavour from juniper berries (Juniperus communis). Gin is one of the broadest categories of spirits, all of various origins, styles, and flavour profiles, that revolve around juniper as a common ingredient.",
                TypeId = Guid.Parse("24cd3f18-f0a8-4f66-bc5b-2108e099cf53"),
            };

            var cocktail = new Cocktail
            {
                Id = Guid.Parse("9ef97551-87f6-40ce-a88b-6c0e876ccb51"),
                Name = "Margarita",
                Description = "The Margarita is one of the most " +
                "popular cocktails in North America—for good reason. " +
                "Combining the tang of lime and the sweetness of o" +
                "range liqueur with the distinctive strength of " +
                "tequila, our classic Margarita strikes all of the right keys."
            };

            var cocktailIngredient = new CocktailIngredients
            {
                CocktailId = cocktail.Id,
                IngredientId = ingredient.Id
            };

            var cocktailIngredient2 = new CocktailIngredients
            {
                CocktailId = cocktail.Id,
                IngredientId = ingredient2.Id
            };

            using (var arrangeContext = new CMContext(options))
            {
                arrangeContext.Ingredients.Add(ingredient);
                arrangeContext.Ingredients.Add(ingredient2);
                arrangeContext.Cocktails.Add(cocktail);
                arrangeContext.CocktailIngredients.Add(cocktailIngredient);
                arrangeContext.CocktailIngredients.Add(cocktailIngredient2);
                arrangeContext.SaveChanges();
            }

            using (var assertContext = new CMContext(options))
            {
                var sut = new CocktailService(assertContext);
                var result = await sut.GetAllCocktailIngredients();

                Assert.AreEqual(2, result.Count());
            }
        }
    }
}
