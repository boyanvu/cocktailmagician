using CocktailsMagician.Data;
using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services;
using CocktailsMagician.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailsMagician.Tests.ServiceTests.BarTests
{
    [TestClass]
    public class Get_All_Bars_ForHM_Should
    {
        [TestMethod]
        public async Task GetAllBars_ForHM_Correct()
        {
            var options = Utils.GetOptions(nameof(GetAllBars_ForHM_Correct));

            var city1 = new City()
            {
                Id = Guid.Parse("68fee6bf-edd0-4121-8b06-37f0c7e11d4a"),
                Name = "Sofia"
            };
            var city2 = new City()
            {
                Id = Guid.Parse("e3e92ad8-b117-42a8-b263-ec351d9234fc"),
                Name = "Plovdiv"
            };
            var city3 = new City()
            {
                Id = Guid.Parse("cc44371d-594f-4c47-a82b-e606bede8d3b"),
                Name = "Varna"
            };
            var city4 = new City()
            {
                Id = Guid.Parse("51d75009-3674-4a35-92f1-48a4981d26bb"),
                Name = "Burgas"
            };


            var bar1 = new Bar()
            {
                Id = Guid.Parse("5fedc033-16db-4d62-b5e6-20eb3a056ead"),
                Name = "Pavement",
                Phone = "0877151152",
                Website = "https://www.facebook.com/pages/%D0%91%D0%B0%D1%80-%D0%9F%D0%B0%D0%B2%D0%B0%D0%B6/662197613861829",
                Description = @"Is incomparable pleasure to have a cup of coffee under the shade of linden trees and greenery of the park in close proximity to the coolness of the fountain. ",
                CityId = city1.Id,
                Address = "at the corner of Angel Kanchev and Solunska",
                AvgRating = 1
            };
            var bar2 = new Bar()
            {
                Id = Guid.Parse("e3be83dd-0c12-41d0-9f05-56554ad74a2d"),
                Name = "Foket Bar",
                Phone = "0888050505",
                Website = "http://www.facebook.com/%D0%9A%D0%B0%D1%84%D0%B5-%D0%A4%D0%BE%D0%BA%D0%B5%D1%82-348364438530436/",
                Description = "We chose the heart of Burgas, just a few steps away from the sea coast, to create the oasis of the pleasure for you. With the commercial music background we offer perfect conditions for the morning cup of coffee or the cocktail at sunset. ",
                CityId = city4.Id,
                Address = "31 Morska Str.",
                AvgRating = 3
            };
            var bar3 = new Bar()
            {
                Id = Guid.Parse("92a05c62-6f33-4dc9-bcc1-c9c946bf693a"),
                Name = "Pappa's Bar",
                Phone = "0898878465",
                Website = "-",
                Description = "Very nice bar",
                CityId = city3.Id,
                Address = "62 Prof. Marin Drinov Str.",
                AvgRating = 5
            };
            var bar4 = new Bar()
            {
                Id = Guid.Parse("1f573fa6-3cc0-48ad-8850-ee7675cc3096"),
                Name = "Konyushnite",
                Phone = "0899516116",
                Website = "https://www.facebook.com/barkonushnite/",
                Description = "Live music",
                CityId = city2.Id,
                Address = "40 Saborna Str.",
                AvgRating = 4
            };

            using (var arrangeContext = new CMContext(options))
            {
                arrangeContext.Cities.Add(city1);
                arrangeContext.Cities.Add(city2);
                arrangeContext.Cities.Add(city3);
                arrangeContext.Cities.Add(city4);
                arrangeContext.Bars.Add(bar1);
                arrangeContext.Bars.Add(bar2);
                arrangeContext.Bars.Add(bar3);
                arrangeContext.Bars.Add(bar4);
                await arrangeContext.SaveChangesAsync();
            }
            //Act,Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarService(assertContext);
                var result = await sut.GetAllBarsForHomePage();
                Assert.AreEqual(bar3.Id, result[0].Id);
                Assert.AreEqual(bar3.Name, result[0].Name);
                Assert.AreEqual(3, result.Count);
            }
        }
    }
}
