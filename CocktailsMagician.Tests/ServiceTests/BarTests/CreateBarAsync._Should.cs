using CocktailsMagician.Data;
using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services.DTO_s;
using CocktailsMagician.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace CocktailsMagician.Tests.ServiceTests.BarTests
{
    [TestClass]
    public class CreateBarAsync
    {
        [TestMethod]
        public async Task CreateBarAsync_Correct()
        {
            //Arrange
            var barName = "Just another bar";
            var options = Utils.GetOptions(nameof(CreateBarAsync_Correct));
            var city = new City()
            {
                Id = Guid.Parse("cc44371d-594f-4c47-a82b-e606bede8d3b"),
                Name = "Varna"
            };
            var barDTO = new BarDTO()
            {
                Id = Guid.Parse("92a05c62-6f33-4dc9-bcc1-c9c946bf693a"),
                Name = barName,
                Phone = "0898878465",
                CityId = Guid.Parse("cc44371d-594f-4c47-a82b-e606bede8d3b"), //Varna
                Address = "62 Prof. Marin Drinov Str.",
            };
            //Act,Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarService(assertContext);
                var result = await sut.CreateBarAsync(barDTO);
                Assert.AreEqual(barName, result.Name);
                Assert.IsInstanceOfType(result, typeof(BarDTO));
            }
        }

        //[TestMethod]
        //public async Task Throw_When_Bar_Already_Exists()
        //{
        //    //Arrange
        //    var barName = "Just another bar";
        //    var options = Utils.GetOptions(nameof(Throw_When_Bar_Already_Exists));
        //    var city = new City()
        //    {
        //        Id = Guid.Parse("cc44371d-594f-4c47-a82b-e606bede8d3b"),
        //        Name = "Varna"
        //    };
        //    var barDTO = new BarDTO()
        //    {
        //        //Id = Guid.Parse("92a05c62-6f33-4dc9-bcc1-c9c946bf693a"),
        //        Name = barName,
        //        Phone = "0898878465",
        //        CityId = Guid.Parse("cc44371d-594f-4c47-a82b-e606bede8d3b"), //Varna
        //        Address = "62 Prof. Marin Drinov Str.",
        //    };
        //    var barDTO2 = new BarDTO()
        //    {
        //        //Id = Guid.Parse("92a05c62-6f33-4dc9-bcc1-c9c946bf693a"),
        //        Name = barName,
        //        Phone = "0898878465",
        //        CityId = Guid.Parse("cc44371d-594f-4c47-a82b-e606bede8d3b"), //Varna
        //        Address = "62 Prof. Marin Drinov Str.",
        //    };
        //    using (var assertContext = new CMContext(options))
        //    {
        //        var sut = new BarService(assertContext);
        //        await sut.CreateBarAsync(barDTO);
        //        await sut.CreateBarAsync(barDTO2);
        //        //await Assert.ThrowsExceptionAsync<Exception>
        //        //  (async () => await sut.CreateBarAsync(barDTO2));
        //    }
        //}
    }
}
