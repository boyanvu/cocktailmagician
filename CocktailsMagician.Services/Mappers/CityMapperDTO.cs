using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailsMagician.Services.Mappers
{
    public static class CityMapperDTO
    {
        public static CityDTO CityMapToDTO(this City city)
        {
            var cityDTO = new CityDTO();
            cityDTO.Id = city.Id;
            cityDTO.Name = city.Name;
            cityDTO.Bars = city.Bars;

            return cityDTO;
        }
    }
}
