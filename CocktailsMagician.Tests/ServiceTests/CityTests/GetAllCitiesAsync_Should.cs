using CocktailsMagician.Data;
using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services.DTO_s;
using CocktailsMagician.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailsMagician.Tests.ServiceTests.CityTests
{
    [TestClass]
    public class GetAllCitiesAsync_Should
    {
        [TestMethod]
        public async Task GetAllCitiesAsync_Correct()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(GetAllCitiesAsync_Correct));
            var city1 = new City()
            {
                Id = Guid.Parse("cc44371d-594f-4c47-a82b-e606bede8d3b"),
                Name = "Varna"
            };
            var city2 = new City()
            {
                Id = Guid.Parse("e3e92ad8-b117-42a8-b263-ec351d9234fc"),
                Name = "Plovdiv"
            };
            using (var arrangeContext = new CMContext(options))
            {
                arrangeContext.Cities.Add(city1);
                arrangeContext.Cities.Add(city2);
                await arrangeContext.SaveChangesAsync();
            }

            //Act,Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new CityService(assertContext);

                var result = await sut.GetAllCitiesAsync();
                Assert.AreEqual(2, result.Count());
                Assert.IsInstanceOfType(result, typeof(IEnumerable<CityDTO>));
            }
        }
    }
}
