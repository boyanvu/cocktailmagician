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
    public class UpdateCityAsync_Should
    {
        [TestMethod]
        public async Task UpdateCityAsync_Correct()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(UpdateCityAsync_Correct));
            var cityId = Guid.Parse("cc44371d-594f-4c47-a82b-e606bede8d3b");
            var newName = "Shumen";
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

                var result = await sut.UpdateCityAsync(cityId, newName);
                Assert.AreEqual(newName, result.Name);
                Assert.IsInstanceOfType(result, typeof(CityDTO));
            }
        }

        [TestMethod]
        public async Task Throw_When_City_NotFound()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(Throw_When_City_NotFound));
            var cityId = Guid.Parse("cc44371d-594f-4c47-a82b-e606bede8d3b");
            var newName = "Shumen";

            //Act,Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new CityService(assertContext);
                await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await sut.UpdateCityAsync(cityId, newName));
            }
        }
    }
}

//public async Task<CityDTO> UpdateCityAsync(Guid id, string name)
//{
//    try
//    {
//        var city = await _cmContext.Cities.FindAsync(id);
//        if (city == null)
//        {
//            throw new ArgumentNullException();
//        }
//        city.Name = name;
//        await _cmContext.SaveChangesAsync();
//        var cityDto = await this.GetCityAsync(id);
//        return cityDto;
//    }
//    catch (Exception)
//    {
//        throw;
//    }
//}