using CocktailsMagician.Data;
using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailsMagician.Tests.ServiceTests.IngredientTypeTests
{
    [TestClass]
    public class Get_All_IngrTypes_Should
    {
        [TestMethod]
        public async Task Get_Correct_Names_IngredientTypes()
        {
            var options = Utils.GetOptions(nameof(Get_Correct_Names_IngredientTypes));
            var ingredientType = new IngredientType
            {
                Id = Guid.Parse("619ac43c-075a-47be-befc-c68249054b85"),
                Name = "Rum"
            };

            var ingredientType2 = new IngredientType()
            {
                Id = Guid.Parse("8ff6497e-800b-43ac-8f53-9492e38d60a1"),
                Name = "Tonic"
            };

            using (var arrangeContext = new CMContext(options))
            {
                arrangeContext.IngredientTypes.Add(ingredientType);
                arrangeContext.IngredientTypes.Add(ingredientType2);
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new CMContext(options))
            {
                var sut = new IngredientTypeService(assertContext);
                var result = await sut.GetAllIngredientTypes();
                Assert.AreEqual("Rum", result.ElementAt(0).Name);
                Assert.AreEqual("Tonic", result.ElementAt(1).Name);
            }
        }
    }
}
