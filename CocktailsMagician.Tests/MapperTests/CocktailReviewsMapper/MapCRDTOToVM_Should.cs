using CocktailsMagician.Areas.Cocktails.Models;
using CocktailsMagician.Services.DTO_s;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CocktailsMagician.Mappers;

namespace CocktailsMagician.Tests.MapperTests.CocktailReviewsMapper
{
    [TestClass]
    public class MapCRDTOToVM_Should
    {
        [TestMethod]
        public void Return_CocktailVM()
        {

            var cocktailReviewDTO = new CocktailReviewDTO()
            {
                Id = Guid.Parse("9ef97551-87f6-40ce-a88b-6c0e876ccb51"),
                CocktailId = Guid.Parse("cc44371d-594f-4c47-a82b-e606bede8d3b"),
                UserId = Guid.Parse("cc44371d-594f-4c47-a82b-e606bede8d3b"),
                Rating = 4,
                Comment = "Nice"           
            };

            var result = cocktailReviewDTO.CocktailReviewsDTOMapToVM();

            Assert.IsInstanceOfType(result, typeof(CocktailReviewViewModel));
        }
    }
}
