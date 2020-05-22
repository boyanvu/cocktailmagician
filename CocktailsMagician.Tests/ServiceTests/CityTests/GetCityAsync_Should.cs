using CocktailsMagician.Data;
using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services.DTO_s;
using CocktailsMagician.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailsMagician.Tests.ServiceTests.CityTests
{
    [TestClass]
    public class GetCityAsync_Should
    {
        [TestMethod]
        public async Task GetCityAsync_Correct()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(GetCityAsync_Correct));
            var cityId = Guid.Parse("cc44371d-594f-4c47-a82b-e606bede8d3b");
            var city = new City()
            {
                Id = cityId,
                Name = "Varna"
            };
            using (var arrangeContext = new CMContext(options))
            {
                arrangeContext.Cities.Add(city);
                await arrangeContext.SaveChangesAsync();
            }

            //Act,Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new CityService(assertContext);

                var result = await sut.GetCityAsync(cityId);
                Assert.AreEqual(cityId, result.Id);
                Assert.IsInstanceOfType(result,typeof(CityDTO));
            }
        }
        [TestMethod]
        public async Task Throw_When_City_DoesNotExist()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(Throw_When_City_DoesNotExist));
            var cityId = Guid.Parse("cc44371d-594f-4c47-a82b-e606bede8d3b");

            //Act,Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new CityService(assertContext);
                await Assert.ThrowsExceptionAsync<ArgumentNullException>
                    (async () => await sut.GetCityAsync(cityId));
            }
        }
    }
}
