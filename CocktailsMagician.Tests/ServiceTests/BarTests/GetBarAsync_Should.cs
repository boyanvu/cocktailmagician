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
    public class GetBarAsync_Should
    {
        [TestMethod]
        public async Task GetBarAsync_Correct()
        {
            //Arrange
            var barName = "Pappa's Bar";
            var barPhone = "0898878465";
            var options = Utils.GetOptions(nameof(GetBarAsync_Correct));
            var city = new City()
            {
                Id = Guid.Parse("cc44371d-594f-4c47-a82b-e606bede8d3b"),
                Name = "Varna"
            };
            var bar = new Bar()
            {
                Id = Guid.Parse("92a05c62-6f33-4dc9-bcc1-c9c946bf693a"),
                Name = barName,
                Phone = barPhone,
                Website = "-",
                Description = "Very nice bar",
                CityId = Guid.Parse("cc44371d-594f-4c47-a82b-e606bede8d3b"), //Varna
                Address = "62 Prof. Marin Drinov Str.",
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
                Guid resultGuid = new Guid("92a05c62-6f33-4dc9-bcc1-c9c946bf693a");
                var result = await sut.GetBarAsync(resultGuid);
                Assert.AreEqual(barName, result.Name);
                Assert.AreEqual(barPhone, result.Phone);
                Assert.IsInstanceOfType(result, typeof(BarDTO));
            }
        }

        [TestMethod]
        public async Task Throw_When_Bar_NotFound()
        {
            var options = Utils.GetOptions(nameof(Throw_When_Bar_NotFound));

            using (var assertContext = new CMContext(options))
            {
                var sut = new BarService(assertContext);
                Guid resultGuid = new Guid("4039e0f3-8d2d-43a5-a82b-477e42371cd6");

                await Assert.ThrowsExceptionAsync<ArgumentNullException>
                    (async () => await sut.GetBarAsync(resultGuid));
            }
        }
    }
}