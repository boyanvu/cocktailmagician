using CocktailsMagician.Data;
using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailsMagician.Tests.ServiceTests.BarTests
{
    [TestClass]
    public class GetBarsFiltered_Should
    {
        [TestMethod]
        public async Task GetBarsFiltered_FilterByName_Correct()
        {
            var firstBarName = "Abc";
            var secondBarName = "Def";
            double firstAvgRating = 3;
            double secondAvgRating = 4;
            //Arrange
            var options = Utils.GetOptions(nameof(GetBarsFiltered_FilterByName_Correct));
            var city = new City()
            {
                Id = Guid.Parse("cc44371d-594f-4c47-a82b-e606bede8d3b"),
                Name = "Varna"
            };
            var firstBar = new Bar()
            {
                Id = Guid.Parse("92a05c62-6f33-4dc9-bcc1-c9c946bf693a"),
                Name = firstBarName,
                Phone = "0898878465",
                CityId = Guid.Parse("cc44371d-594f-4c47-a82b-e606bede8d3b"), //Varna
                Address = "62 Prof. Marin Drinov Str.",
                AvgRating = firstAvgRating
            };
            var secondBar = new Bar()
            {
                Id = Guid.Parse("92a05c62-6f33-4dc9-bcc1-c9c946bf693b"),
                Name = secondBarName,
                Phone = "0898878466",
                CityId = Guid.Parse("cc44371d-594f-4c47-a82b-e606bede8d3b"), //Varna
                Address = "62 Prof. Marin Drinov Str.",
                AvgRating = secondAvgRating
            };
            using (var arrangeContext = new CMContext(options))
            {
                arrangeContext.Cities.Add(city);
                arrangeContext.Bars.Add(firstBar);
                arrangeContext.Bars.Add(secondBar);
                await arrangeContext.SaveChangesAsync();
            }
            //Act,Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarService(assertContext);
                var result = await sut.GetBarsFiltered(null, firstBarName);
                Assert.AreEqual(1, result.Count);
                Assert.AreEqual(firstBarName, result.First().Name);
            }
        }

        [TestMethod]
        public async Task GetBarsFiltered_SortByName_Correct()
        {
            var firstBarName = "Abc";
            var secondBarName = "Def";
            double firstAvgRating = 3;
            double secondAvgRating = 4;
            //Arrange
            var options = Utils.GetOptions(nameof(GetBarsFiltered_SortByName_Correct));
            var city = new City()
            {
                Id = Guid.Parse("cc44371d-594f-4c47-a82b-e606bede8d3b"),
                Name = "Varna"
            };
            var firstBar = new Bar()
            {
                Id = Guid.Parse("92a05c62-6f33-4dc9-bcc1-c9c946bf693a"),
                Name = firstBarName,
                Phone = "0898878465",
                CityId = Guid.Parse("cc44371d-594f-4c47-a82b-e606bede8d3b"), //Varna
                Address = "62 Prof. Marin Drinov Str.",
                AvgRating = firstAvgRating
            };
            var secondBar = new Bar()
            {
                Id = Guid.Parse("92a05c62-6f33-4dc9-bcc1-c9c946bf693b"),
                Name = secondBarName,
                Phone = "0898878466",
                CityId = Guid.Parse("cc44371d-594f-4c47-a82b-e606bede8d3b"), //Varna
                Address = "62 Prof. Marin Drinov Str.",
                AvgRating = secondAvgRating
            };
            using (var arrangeContext = new CMContext(options))
            {
                arrangeContext.Cities.Add(city);
                arrangeContext.Bars.Add(firstBar);
                arrangeContext.Bars.Add(secondBar);
                await arrangeContext.SaveChangesAsync();
            }
            //Act,Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarService(assertContext);
                var result = await sut.GetBarsFiltered("name_desc", null);
                Assert.AreEqual(2, result.Count);
                Assert.AreEqual(secondBarName, result.First().Name);
            }
        }

        [TestMethod]
        public async Task GetBarsFiltered_SortByRating_Correct()
        {
            var firstBarName = "Abc";
            var secondBarName = "Def";
            double firstAvgRating = 3;
            double secondAvgRating = 4;
            //Arrange
            var options = Utils.GetOptions(nameof(GetBarsFiltered_SortByRating_Correct));
            var city = new City()
            {
                Id = Guid.Parse("cc44371d-594f-4c47-a82b-e606bede8d3b"),
                Name = "Varna"
            };
            var firstBar = new Bar()
            {
                Id = Guid.Parse("92a05c62-6f33-4dc9-bcc1-c9c946bf693a"),
                Name = firstBarName,
                Phone = "0898878465",
                CityId = Guid.Parse("cc44371d-594f-4c47-a82b-e606bede8d3b"), //Varna
                Address = "62 Prof. Marin Drinov Str.",
                AvgRating = firstAvgRating
            };
            var secondBar = new Bar()
            {
                Id = Guid.Parse("92a05c62-6f33-4dc9-bcc1-c9c946bf693b"),
                Name = secondBarName,
                Phone = "0898878466",
                CityId = Guid.Parse("cc44371d-594f-4c47-a82b-e606bede8d3b"), //Varna
                Address = "62 Prof. Marin Drinov Str.",
                AvgRating = secondAvgRating
            };
            using (var arrangeContext = new CMContext(options))
            {
                arrangeContext.Cities.Add(city);
                arrangeContext.Bars.Add(firstBar);
                arrangeContext.Bars.Add(secondBar);
                await arrangeContext.SaveChangesAsync();
            }
            //Act,Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarService(assertContext);
                var result = await sut.GetBarsFiltered("rating_desc", null);
                Assert.AreEqual(2, result.Count);
                Assert.AreEqual(secondAvgRating, result.First().AvgRating);
            }
        }

    }
}
