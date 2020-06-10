using CocktailsMagician.Data;
using CocktailsMagician.Services.DTO_s;
using CocktailsMagician.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace CocktailsMagician.Tests.ServiceTests.CityTests
{
    [TestClass]
    public class CreateCityAsync_Should
    {
        [TestMethod]
        public async Task CreateCityAsync_Correct()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(CreateCityAsync_Correct));
            var cityDTO = new CityDTO()
            {
                Id = Guid.Parse("cc44371d-594f-4c47-a82b-e606bede8d3b"),
                Name = "Varna"
            };

            //Act,Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new CityService(assertContext);

                var result = await sut.CreateCityAsync(cityDTO);
                Assert.AreEqual(cityDTO.Id, result.Id);
                Assert.AreEqual(cityDTO.Name,result.Name);
            }
        }
    }
}
