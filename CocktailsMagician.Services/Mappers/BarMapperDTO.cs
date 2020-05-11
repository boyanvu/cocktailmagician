using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailsMagician.Services.Mappers
{
    public static class BarMapperDTO
    {
        public static BarDTO MapBarToDTO(this Bar bar)
        {
            var barDTO = new BarDTO();
            barDTO.Id = bar.Id;
            barDTO.Name = bar.Name;
            barDTO.Phone = bar.Phone;
            barDTO.Website = bar.Website;
            barDTO.Description = bar.Description;
            barDTO.City = bar.City;
            barDTO.CityId = bar.CityId;
            barDTO.AvgRating = bar.AvgRating;
            barDTO.UnlistedOn = bar.UnlistedOn;
            barDTO.BarReviews = bar.BarReviews;

            return barDTO;
        }
    }
}
