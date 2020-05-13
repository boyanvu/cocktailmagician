using CocktailsMagician.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailsMagician.Services.Contracts
{
    public interface ICityService
    {
        Task<CityDTO> GetCityAsync(Guid id);
        Task<IEnumerable<CityDTO>> GetAllCitiesAsync();
        Task<CityDTO> CreateCityAsync(CityDTO cityDTO);
        Task<CityDTO> UpdateCityAsync(Guid id, string name);
        //Task<bool> DeleteCityAsync(Guid id);
    }
}
