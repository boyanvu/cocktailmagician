using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services.DTO_s;
using CocktailsMagician.Services.Mappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CocktailsMagician.Tests.MapperTests.CocktailMapper
{
    [TestClass]
    public class MapCocktailToDTO_Should
    {
        [TestMethod]
        public void Return_CocktailDTO()
        {
            var cocktail = new Cocktail()
            {
                Id = Guid.Parse("9ef97551-87f6-40ce-a88b-6c0e876ccb51"),
                Name = "Margarita",
                Description = "The Margarita is one of the most " +
               "popular cocktails in North America—for good reason. " +
               "Combining the tang of lime and the sweetness of o" +
               "range liqueur with the distinctive strength of " +
               "tequila, our classic Margarita strikes all of the right keys."
            };

            var result = cocktail.CocktailMapToDTO();

            Assert.IsInstanceOfType(result, typeof(CocktailDTO));
        }
    }
}
