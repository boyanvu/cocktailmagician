using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services.DTO_s;
using CocktailsMagician.Services.Mappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CocktailsMagician.Tests.MapperTests.IngredientTypeMapper
{
    [TestClass]
    public class MapIngrTypeToDTO_Should
    {
        [TestMethod]
        public void Return_IngredientTypeDTO()
        {
            var ingredientType = new IngredientType
            {
                Id = Guid.Parse("619ac43c-075a-47be-befc-c68249054b85"),
                Name = "Rum"
            };

            var result = ingredientType.IngredientTypeMapToDTO();

            Assert.IsInstanceOfType(result, typeof(IngredientTypeDTO));
        }
    }
}
