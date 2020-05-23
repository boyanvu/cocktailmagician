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

namespace CocktailsMagician.Tests.ServiceTests.CocktailIngredientsTests
{
    [TestClass]
    public class Add_Ingredient_To_Cocktail_Should
    {
        [TestMethod]
        public async Task Return_Correct_CIDTO()
        {
            var options = Utils.GetOptions(nameof(Return_Correct_CIDTO));

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

            var cocktailIngredientDTO = new CocktailIngredientsDTO
            {
                CocktailId = cocktail.Id,
                IngredientId = ingredient.Id,
            };

            using (var assertContext = new CMContext(options))
            {
                var sut = new CocktailService(assertContext);
                var result = await sut.AddIngredientToCocktail(cocktailIngredientDTO);

                Assert.AreEqual(cocktailIngredientDTO.CocktailId, assertContext.
                    CocktailIngredients.First().CocktailId);
            }
        }


        [TestMethod]
        public async Task Throw_When_CINotFound()
        {
            var options = Utils.GetOptions(nameof(Throw_When_CINotFound));

            using (var assertContext = new CMContext(options))
            {
                var sut = new CocktailService(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>
                    (async () => await sut.AddIngredientToCocktail(null));
            }
        }
    }
}
