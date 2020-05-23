using CocktailsMagician.Data;
using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services;
using CocktailsMagician.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailsMagician.Tests.ServiceTests.IngredientsTests
{
    [TestClass]
    public class Get_Ingredients_Filtered_Should
    {
        [TestMethod]
        public async Task GetIngredients_SearchedByName_Correct()
        {

            //Arrange
            var options = Utils.GetOptions(nameof(GetIngredients_SearchedByName_Correct));

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
            //Act,Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new IngredientService(assertContext);
                var result = await sut.GetAllIngredients(null, null, "Gin", null);
                Assert.AreEqual(1, result.Count);
                Assert.AreEqual("Gin", result.First().Name);
            }
        }

        [TestMethod]
        public async Task GetIngredients_FilteredByName_Correct()
        {

            //Arrange
            var options = Utils.GetOptions(nameof(GetIngredients_FilteredByName_Correct));

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
            //Act,Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new IngredientService(assertContext);
                var result = await sut.GetAllIngredients(null, "Gin", null , null);
                Assert.AreEqual(2, result.Count);
                Assert.AreEqual("Gin", result.First().Name);
            }
        }

        [TestMethod]
        public async Task GetIngredients_SortedByAbv_Correct()
        {

            //Arrange
            var options = Utils.GetOptions(nameof(GetIngredients_SortedByAbv_Correct));

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
            //Act,Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new IngredientService(assertContext);
                var result = await sut.GetAllIngredients("abv_desc", null, null, null);
                Assert.AreEqual(2, result.Count);
                Assert.AreEqual("Gin", result.First().Name);
            }
        }
    }
}
