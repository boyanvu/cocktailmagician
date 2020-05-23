using CocktailsMagician.Areas.Cocktails.Models;
using CocktailsMagician.Mappers;
using CocktailsMagician.Services.DTO_s;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailsMagician.Tests.MapperTests.CocktailIngredientsMapper
{
    [TestClass]
    public class MapCIDTOToVM
    {
        [TestMethod]
        public void Return_CocktailIngredientVM()
        {
            var cocktailDTO = new CocktailDTO()
            {
                Id = Guid.Parse("9ef97551-87f6-40ce-a88b-6c0e876ccb51"),
                Name = "Margarita",
                Description = "The Margarita is one of the most " +
               "popular cocktails in North America—for good reason. " +
               "Combining the tang of lime and the sweetness of o" +
               "range liqueur with the distinctive strength of " +
               "tequila, our classic Margarita strikes all of the right keys."
            };

            var ingredientDTO = new IngredientDTO
            {
                Id = Guid.Parse("1b98e50e-8314-4b1e-82df-491c3c8d086f"),
                Name = "Gin",
                Abv = 40,
                Description = "Gin is a distilled alcoholic drink that derives its " +
                         "predominant flavour from juniper berries (Juniperus communis). " +
                         "Gin is one of the broadest categories of spirits, all of various origins, styles," +
                         " and flavour profiles, that revolve around juniper as a common ingredient.",
                TypeId = Guid.Parse("27309394-4ac3-4dc6-a81a-c8e147e378f0"),
            };

            var ciDTO = new CocktailIngredientsDTO
            {
                CocktailId = cocktailDTO.Id,
                IngredientId = ingredientDTO.Id,
                CocktailName = cocktailDTO.Name,
                IngredientName = ingredientDTO.Name,
            };

            var result = ciDTO.CocktailIngredientDTOMapToVM();

            Assert.IsInstanceOfType(result, typeof(CocktailIngredientsViewModel));
        }
    }
}
