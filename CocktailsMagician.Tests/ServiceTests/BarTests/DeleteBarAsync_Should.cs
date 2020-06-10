using CocktailsMagician.Data;
using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace CocktailsMagician.Tests.ServiceTests.BarTests
{
    [TestClass]
    public class DeleteBarAsync_Should
    {
        [TestMethod]
        public async Task DeleteBarAsync_Correct()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(DeleteBarAsync_Correct));
            var id = Guid.Parse("92a05c62-6f33-4dc9-bcc1-c9c946bf693a");
            var city = new City()
            {
                Id = Guid.Parse("cc44371d-594f-4c47-a82b-e606bede8d3b"),
                Name = "Varna"
            };
            var bar = new Bar()
            {
                Id = id,
                Name = "Just another bar",
                Phone = "0898878465",
                CityId = Guid.Parse("cc44371d-594f-4c47-a82b-e606bede8d3b"), //Varna
                Address = "62 Prof. Marin Drinov Str.",
            };
            using(var arrangeContext = new CMContext(options))
            {
                arrangeContext.Bars.Add(bar);
                await arrangeContext.SaveChangesAsync();
            }
            //Act,Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarService(assertContext);
                var result = await sut.DeleteBarAsync(id);
                Assert.IsTrue(result);
            }
        }
        [TestMethod]
        public async Task Return_False_If_Bar_IsMissing()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(Return_False_If_Bar_IsMissing));
            var id = Guid.Parse("92a05c62-6f33-4dc9-bcc1-c9c946bf693a");
            //Act,Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarService(assertContext);
                var result = await sut.DeleteBarAsync(id);
                Assert.IsFalse(result);
            }
        }
    }
}

