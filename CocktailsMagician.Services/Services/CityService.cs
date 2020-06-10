using CocktailsMagician.Data;
using CocktailsMagician.Services.Contracts;
using CocktailsMagician.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CocktailsMagician.Services.Mappers;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CocktailsMagician.Services.Services
{
    public class CityService : ICityService
    {
        private readonly CMContext _cmContext;
        public CityService(CMContext cmContext)
        {
            this._cmContext = cmContext;
        }
        public async Task<CityDTO> GetCityAsync(Guid id)
        {
            var city = await _cmContext.Cities.FindAsync(id);
            if (city==null)
            {
                throw new ArgumentNullException("City does not exist.");
            }
            var cityDTO = city.CityMapToDTO();
            return cityDTO;
        }
        public async Task<IEnumerable<CityDTO>> GetAllCitiesAsync()
        {
            var cityDTO = await _cmContext.Cities
                .Select(c => c.CityMapToDTO())
                .ToListAsync();
            return cityDTO;
        }
        public async Task<CityDTO> CreateCityAsync(CityDTO cityDTO)
        {
            var city = cityDTO.CityDTOMapToModel();
            await _cmContext.AddAsync(city);
            await _cmContext.SaveChangesAsync();
            return cityDTO;
        }
        public async Task<CityDTO> UpdateCityAsync(Guid id, string name)
        {
            try
            {
                var city = await _cmContext.Cities.FindAsync(id);
                if (city == null)
                {
                    throw new ArgumentNullException("The city does niot exist.");
                }
                city.Name = name;
                await _cmContext.SaveChangesAsync();
                var cityDto = await this.GetCityAsync(id);
                return cityDto;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //public async Task<bool> DeleteCityAsync(Guid id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
