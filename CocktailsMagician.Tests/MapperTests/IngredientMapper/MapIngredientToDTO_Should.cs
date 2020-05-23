using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services.DTO_s;
using CocktailsMagician.Services.Mappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailsMagician.Tests.MapperTests.IngredientMapper
{
    [TestClass]
    public class MapIngredientToDTO_Should
    {
        [TestMethod]
        public void Return_IngredientDTO()
        {
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

            var result = ingredient.IngredientMapToDTO();

            Assert.IsInstanceOfType(result, typeof(IngredientDTO));
        }
    }

}
