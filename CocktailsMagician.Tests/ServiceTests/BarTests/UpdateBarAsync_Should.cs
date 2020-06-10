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
    public class UpdateBarAsync_Should
    {
        [TestMethod]
        public async Task UpdateBarAsync_Correct()
        {
            //Arrange           
            var options = Utils.GetOptions(nameof(UpdateBarAsync_Correct));
            var barName = "Aaa";
            var city = new City()
            {
                Id = Guid.Parse("cc44371d-594f-4c47-a82b-e606bede8d3b"),
                Name = "Varna"
            };
            var bar = new Bar()
            {
                Id = Guid.Parse("92a05c62-6f33-4dc9-bcc1-c9c946bf693a"),
                Name = barName,
                Phone = "0898878465",
                CityId = Guid.Parse("cc44371d-594f-4c47-a82b-e606bede8d3b"), //Varna
                Address = "62 Prof. Marin Drinov Str.",
            };
            using (var arrangeContext = new CMContext(options))
            {
                arrangeContext.Cities.Add(city);
                arrangeContext.Bars.Add(bar);
                await arrangeContext.SaveChangesAsync();
            }
            var barNameNew = "Bbb";
            var barDTO = new BarDTO()
            {
                Id = Guid.Parse("92a05c62-6f33-4dc9-bcc1-c9c946bf693a"),
                Name = barNameNew,
                Phone = "0898878465",
                CityId = Guid.Parse("cc44371d-594f-4c47-a82b-e606bede8d3b"), //Varna
                Address = "62 Prof. Marin Drinov Str.",
            };
            //Act,Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarService(assertContext);
                var result = await sut.UpdateBarAsync(barDTO);
                Assert.AreEqual(barNameNew, result.Name);
            }
        }

        [TestMethod]
        public async Task Throw_When_Bar_IsMissing()
        {
            //Arrange
            var options = Utils.GetOptions(nameof(Throw_When_Bar_IsMissing));

            var barNameNew = "Bbb";
            var barDTO = new BarDTO()
            {
                Id = Guid.Parse("92a05c62-6f33-4dc9-bcc1-c9c946bf693a"),
                Name = barNameNew,
                Phone = "0898878465",
                CityId = Guid.Parse("cc44371d-594f-4c47-a82b-e606bede8d3b"), //Varna
                Address = "62 Prof. Marin Drinov Str.",
            };
            //Act,Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarService(assertContext);
                await Assert.ThrowsExceptionAsync<ArgumentNullException>
                    (async () => await sut.UpdateBarAsync(barDTO));
            }
        }

        [TestMethod]
        public async Task Throw_When_City_IsMissing()
        {
            //Arrange           
            var options = Utils.GetOptions(nameof(Throw_When_City_IsMissing));
            var barName = "Aaa";
            var city = new City()
            {
                Id = Guid.Parse("cc44371d-594f-4c47-a82b-e606bede8d3b"),
                Name = "Varna"
            };
            var bar = new Bar()
            {
                Id = Guid.Parse("92a05c62-6f33-4dc9-bcc1-c9c946bf693a"),
                Name = barName,
                Phone = "0898878465",
                CityId = Guid.Parse("cc44371d-594f-4c47-a82b-e606bede8d3b"), //Varna
                Address = "62 Prof. Marin Drinov Str.",
            };
            using (var arrangeContext = new CMContext(options))
            {
                arrangeContext.Cities.Add(city);
                arrangeContext.Bars.Add(bar);
                await arrangeContext.SaveChangesAsync();
            }
            var barNameNew = "Bbb";
            var barDTO = new BarDTO()
            {
                Id = Guid.Parse("92a05c62-6f33-4dc9-bcc1-c9c946bf693a"),
                Name = barNameNew,
                Phone = "0898878465",
                CityId = Guid.Parse("aa44371d-594f-4c47-a82b-e606bede8d3a"), // Non existing
                Address = "62 Prof. Marin Drinov Str.",
            };
            //Act,Assert
            using (var assertContext = new CMContext(options))
            {
                var sut = new BarService(assertContext);
                await Assert.ThrowsExceptionAsync<ArgumentException>
                    (async () => await sut.UpdateBarAsync(barDTO));
            }
        }
    }
}
//public async Task<BarDTO> UpdateBarAsync(BarDTO barDTO)
//{
//    var bar = await _cmContext.Bars
//        .Where(b => b.Id == barDTO.Id)
//        .FirstOrDefaultAsync(b => b.UnlistedOn == null);

//    if (bar == null)
//    {
//        throw new ArgumentNullException("Bar does not exist.");
//    }

//    if (barDTO.Name != null)
//        bar.Name = barDTO.Name;

//    if (barDTO.Phone != null)
//        bar.Phone = barDTO.Phone;

//    if (barDTO.Website != null)
//        bar.Website = barDTO.Website;

//    if (barDTO.Description != null)
//        bar.Description = barDTO.Description;

//    if (barDTO.CityId != null)
//    {
//        if (!await _cmContext.Cities.AnyAsync(c => c.Id == barDTO.CityId))
//        {
//            throw new ArgumentException();
//        }
//        bar.CityId = barDTO.CityId;
//    }

//    if (barDTO.Address != null)
//        bar.Address = barDTO.Address;


//    await _cmContext.SaveChangesAsync();


//    //var barDto = bar.MapBarToDTO();
//    return barDTO;
//}