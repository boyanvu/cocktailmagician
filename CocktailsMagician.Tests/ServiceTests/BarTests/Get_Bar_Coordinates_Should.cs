using CocktailsMagician.Data;
using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services.DTO_s;
using CocktailsMagician.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailsMagician.Tests.ServiceTests.BarTests
{
    [TestClass]
    public class Get_Bar_Coordinates_Should
    {
        [TestMethod]
        public async Task Get_Correct_Coordinates()
        {
            var options = Utils.GetOptions(nameof(Get_Correct_Coordinates));
            var city = new City()
            {
                Id = Guid.Parse("cc44371d-594f-4c47-a82b-e606bede8d3b"),
                Name = "Burgas"
            };
            var bar = new Bar
            {
                Id = Guid.Parse("e3be83dd-0c12-41d0-9f05-56554ad74a2d"),
                Name = "Foket Bar",
                Phone = "0888050505",
                Website = "http://www.facebook.com/%D0%9A%D0%B0%D1%84%D0%B5-%D0%A4%D0%BE%D0%BA%D0%B5%D1%82-348364438530436/",
                Description = "We chose the heart of Burgas, just a few steps away from the sea coast, to create the oasis of the pleasure for you. With the commercial music background we offer perfect conditions for the morning cup of coffee or the cocktail at sunset. ",
                CityId = city.Id,
                Address = "31 Morska Str."
            };
            var barDTO = new BarDTO()
            {
                Id = Guid.Parse("e3be83dd-0c12-41d0-9f05-56554ad74a2d"),
                Name = "Foket Bar",
                Phone = "0888050505",
                Website = "http://www.facebook.com/%D0%9A%D0%B0%D1%84%D0%B5-%D0%A4%D0%BE%D0%BA%D0%B5%D1%82-348364438530436/",
                Description = "We chose the heart of Burgas, just a few steps away from the sea coast, to create the oasis of the pleasure for you. With the commercial music background we offer perfect conditions for the morning cup of coffee or the cocktail at sunset. ",
                CityId = city.Id,
                Address = "31 Morska Str."
            };

            using (var arrangeContext = new CMContext(options))
            {
                arrangeContext.Cities.Add(city);
                arrangeContext.Bars.Add(bar);
                await arrangeContext.SaveChangesAsync();
            }
            //Act,Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarService(assertContext);
                var result = await sut.ParseApiLocationResult(barDTO);
                Assert.AreEqual(42.4936616, result.Latitude);
                Assert.AreEqual(27.4721276, result.Longitude);
                Assert.IsInstanceOfType(result, typeof(BarDTO));
            }
        }

        [TestMethod]
        public async Task Throw_If_Bar_IsNull()
        {
            var options = Utils.GetOptions(nameof(Throw_If_Bar_IsNull));

            using (var assertContext = new CMContext(options))
            {
                var sut = new BarService(assertContext);

                await Assert.ThrowsExceptionAsync<InvalidOperationException>
                    (async () => await sut.ParseApiLocationResult(null));
            }
        }
    }
}
