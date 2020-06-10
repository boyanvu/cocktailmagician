using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CocktailsMagician.Data;
using CocktailsMagician.Services.Contracts;
using CocktailsMagician.Services.DTO_s;
using Microsoft.EntityFrameworkCore;
using CocktailsMagician.Services.Mappers;
using CocktailsMagician.Data.Entities;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CocktailsMagician.Services.Services
{
    public class BarService : IBarService
    {
        private readonly CMContext _cmContext;
        public BarService(CMContext cmContext)
        {
            this._cmContext = cmContext;
        }
        public async Task<BarDTO> GetBarAsync(Guid id)
        {
            var bar = await _cmContext.Bars
                .Include(b=>b.City)
                .Include(b=>b.BarReviews)
                    .ThenInclude(br=>br.User)
                .Include(b => b.BarReviews)
                    .ThenInclude(br => br.BarReviewLikes)
                    .ThenInclude(brl => brl.User)
                .FirstOrDefaultAsync(b => b.Id == id);
            if (bar == null)
            {
                throw new ArgumentNullException("Bar does not exist.");
            }

            var barDto = bar.MapBarToDTO();
            return barDto;
        }

        public async Task<IEnumerable<BarDTO>> GetAllBarsAsync()
        {
            var barsDto = await _cmContext.Bars
                .Include(b => b.City)
                .Select(b => b.MapBarToDTO())
                .ToListAsync();
            return barsDto;
        }

        public async Task<List<BarDTO>> GetBarsFiltered(string sortOrder, string searchString)
        {

            var bars = (IQueryable<Bar>)_cmContext.Bars
                .Include(b => b.City)
                .Include(b => b.BarReviews)
                    .ThenInclude(br => br.User);


            if (!String.IsNullOrEmpty(searchString))
            {
                bars = bars
                    .Where(b => b.Name.Contains(searchString) 
                            || b.City.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    bars = bars.OrderByDescending(b => b.Name);
                    break;
                case "rating":
                    bars = bars.OrderBy(b => b.AvgRating);
                    break;
                case "rating_desc":
                    bars = bars.OrderByDescending(b => b.AvgRating);
                    break;
                default:
                    bars = bars.OrderBy(b => b.Name);
                    break;
            }

            var barDTOs = await bars
                //.Where(b => b.UnlistedOn == null)
                .Select(b => b.MapBarToDTO())
                .ToListAsync();

            return barDTOs;
        }
        public async Task<BarDTO> CreateBarAsync(BarDTO barDTO)
        {
            try
            {
                var bar = barDTO.BarDTOMapToModel();
                await _cmContext.Bars.AddAsync(bar);
                await _cmContext.SaveChangesAsync();
                return barDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BarDTO> UpdateBarAsync(BarDTO barDTO)
        {
            var bar = await _cmContext.Bars
                .Where(b=>b.Id == barDTO.Id)
                .FirstOrDefaultAsync(b => b.UnlistedOn == null);

            if (bar == null)
            {
                throw new ArgumentNullException("Bar does not exist.");
            }

            if (barDTO.Name != null)
                bar.Name = barDTO.Name;

            if (barDTO.Phone != null)
                bar.Phone = barDTO.Phone;

            if (barDTO.Website != null)
                bar.Website = barDTO.Website;

            if (barDTO.Description != null)
                bar.Description = barDTO.Description;

            if (barDTO.CityId != null)
            {
                if (!await _cmContext.Cities.AnyAsync(c => c.Id == barDTO.CityId))
                {
                    throw new ArgumentException();
                }
                bar.CityId = barDTO.CityId;
            }

            if (barDTO.Address != null)
            {
                bar.Address = barDTO.Address;
                bar.Latitude = barDTO.Latitude;
                bar.Longitude = barDTO.Longitude;
            }

            await _cmContext.SaveChangesAsync();        
            //var barDto = bar.MapBarToDTO();
            return barDTO;
        }

        public async Task<bool> DeleteBarAsync(Guid id)
        {
            var bar = await _cmContext.Bars
                .Where(b => b.UnlistedOn == null)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (bar == null)
            {
                return false;
            }
            bar.UnlistedOn = DateTime.UtcNow;
            await _cmContext.SaveChangesAsync();
            return true;
        }


        public async Task<bool> AddCocktailToBarAsync(Guid barId, Guid cocktailId)
        {
            if (!await _cmContext.Cocktails.AnyAsync(c => c.UnlistedOn == null && c.Id == cocktailId))
            {
                throw new ArgumentNullException("Cocktail is not available.");
            }
            if (!await _cmContext.Bars.AnyAsync(b => b.UnlistedOn == null && b.Id == barId))
            {
                throw new ArgumentNullException("Bar is not available.");
            }
            var barCocktail = await _cmContext.BarCocktails
                .Where(bc => bc.BarId == barId && bc.CocktailId == cocktailId)
                .FirstOrDefaultAsync();

            if (barCocktail == null)
            {
                var barCocktailNew = new BarCocktail()
                {
                    BarId = barId,
                    CocktailId = cocktailId
                };
                _cmContext.BarCocktails.Add(barCocktailNew);
            }
            else if(barCocktail.UnlistedOn != null)
            {
                barCocktail.UnlistedOn = null;
            }
            if (_cmContext.ChangeTracker.HasChanges())
            {
                try
                {
                    await _cmContext.SaveChangesAsync();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return true;
        }

        public async Task<bool> RemoveCocktailFromBarAsync(Guid barId, Guid cocktailId)
        {
            var barCocktail = await _cmContext.BarCocktails
                .Where(bc => bc.BarId == barId && bc.CocktailId == cocktailId)
                .FirstOrDefaultAsync(bc => bc.UnlistedOn == null);

            if (barCocktail == null)
            {
                throw new ArgumentNullException("The specific bar-cocktail combination is unlisted or does not exist.");
            }
            else
            {
                barCocktail.UnlistedOn = DateTime.UtcNow;
                try
                {
                    await _cmContext.SaveChangesAsync();
                }
                catch (Exception)
                {
                    throw;
                }
                return true;
            }
        }

        public async Task<string> CallApiForLocation(string url)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, $"{url}");
            var response = await client.SendAsync(request);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<BarDTO> ParseApiLocationResult(BarDTO barDTO)
        {
            var bar = await _cmContext.Bars
               .Include(b => b.City)
               .Where(b => b.UnlistedOn == null)
               .FirstOrDefaultAsync(b => b.Id == barDTO.Id);

            if (bar == null)
            {
                var city = await _cmContext.Cities
               .Where(b => b.UnlistedOn == null)
               .FirstOrDefaultAsync(c => c.Id == barDTO.CityId);
                var barCity = city.Name.ToLower();
                var barCountry = "bulgaria";
                var barAdress = barDTO.Address.Replace(" ", "&").TrimEnd('.');

                var url = $"https://nominatim.openstreetmap.org/search?q={barCountry}+{barCity}+{barAdress}&accept-language=en&format=json&addressdetails=1&limit=10&polygon_svg=1&email=lssah@protonmail.com";
               
                var apiResult = await CallApiForLocation(url);

                if (string.IsNullOrEmpty(apiResult) || apiResult == "[]")
                {
                    barDTO.Latitude = 0;
                    barDTO.Longitude = 0;
                }

                var apiStringToJArr = JsonConvert.DeserializeObject<JArray>(apiResult);
                var firstResultJObj = apiStringToJArr.First().ToObject<JObject>();

                foreach (JProperty item in firstResultJObj.Children())
                {
                    if (item.Name == "lat")
                    {
                        barDTO.Latitude = Convert.ToDouble(item.Value);
                    }
                    else if (item.Name == "lon")
                    {
                        barDTO.Longitude = Convert.ToDouble(item.Value);
                    }
                }
            }
            else
            {
                var barCity = bar.City.Name.ToLower();
                var barCountry = "bulgaria";
                var barAdress = bar.Address.Replace(" ", "&").TrimEnd('.');

                var url = $"https://nominatim.openstreetmap.org/search?q={barCountry}+{barCity}+{barAdress}&accept-language=en&format=json&addressdetails=1&limit=10&polygon_svg=1&email=lssah@protonmail.com";
                var apiResult = await CallApiForLocation(url);

                if (string.IsNullOrEmpty(apiResult) || apiResult == "[]")
                {
                    barDTO.Latitude = 0;
                    barDTO.Longitude = 0;
                }

                var apiStringToJArr = JsonConvert.DeserializeObject<JArray>(apiResult);
                var firstResultJObj = apiStringToJArr.First().ToObject<JObject>();

                foreach (JProperty item in firstResultJObj.Children())
                {
                    if (item.Name == "lat")
                    {
                        barDTO.Latitude = Convert.ToDouble(item.Value);
                    }
                    else if (item.Name == "lon")
                    {
                        barDTO.Longitude = Convert.ToDouble(item.Value);
                    }
                }
            }

            return barDTO;
        }

        public async Task<List<BarDTO>> GetAllBarsForHomePage()
        {
            var barsDto = await _cmContext.Bars
              .Include(b => b.City)
              .Where(b => b.UnlistedOn == null)
              .OrderByDescending(b => b.AvgRating)
              .Take(3)
              .Select(b => b.MapBarToDTO())
              .ToListAsync();

            return barsDto;
        }
    }
}
