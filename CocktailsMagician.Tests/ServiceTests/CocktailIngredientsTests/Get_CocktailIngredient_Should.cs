using CocktailsMagician.Data;
using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services;
using CocktailsMagician.Services.DTO_s;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailsMagician.Tests.ServiceTests.CocktailIngredientsTests
{
    [TestClass]
    public class Get_CocktailIngredient_Should
    {
        [TestMethod]
        public async Task Return_Correct_CocktailIngredient()
        {
            var options = Utils.GetOptions(nameof(Return_Correct_CocktailIngredient));

            var ingredient = new Ingredient
            {
                Id = Guid.Parse("4039e0f3-8d2d-43a5-a82b-477e42371cd6"),
                Name = "Martini Extra Dry",
                Abv = 0,
                Description = "",
                TypeId = Guid.Parse("619ac43c-075a-47be-befc-c68249054b85"),
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
                CocktailId = Guid.Parse("9ef97551-87f6-40ce-a88b-6c0e876ccb51"),
                IngredientId = Guid.Parse("4039e0f3-8d2d-43a5-a82b-477e42371cd6"),
            };

            using (var arrangeContext = new CMContext(options))
            {
                arrangeContext.Ingredients.Add(ingredient);
                arrangeContext.Cocktails.Add(cocktail);
                arrangeContext.CocktailIngredients.Add(cocktailIngredient);

                arrangeContext.SaveChanges();
            }

            using (var assertContext = new CMContext(options))
            {
                var sut = new CocktailService(assertContext);
                var result = await sut.GetCocktailIngredient(cocktail.Id, ingredient.Id);

                Assert.AreEqual(result.CocktailId, cocktailIngredient.CocktailId);
                Assert.AreEqual(result.IngredientId, cocktailIngredient.IngredientId);
                Assert.IsInstanceOfType(result, typeof(CocktailIngredientsDTO));
            }
        }


        [TestMethod]
        public async Task Throw_When_CocktailIngredientNotFound()
        {
            var options = Utils.GetOptions(nameof(Throw_When_CocktailIngredientNotFound));

            using (var assertContext = new CMContext(options))
            {
                var sut = new CocktailService(assertContext);

                Guid cocktailId = Guid.Parse("9ef97551-87f6-40ce-a88b-6c0e876ccb51");
                Guid ingredientId = Guid.Parse("4039e0f3-8d2d-43a5-a82b-477e42371cd6");

                Assert.IsNull(await sut.GetCocktailIngredient(cocktailId, ingredientId));
            }
        }

    }
}
