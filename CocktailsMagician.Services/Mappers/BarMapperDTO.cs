using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            barDTO.City = bar.City.Name;
            barDTO.CityId = bar.CityId;
            barDTO.AvgRating = bar.AvgRating;
            barDTO.UnlistedOn = bar.UnlistedOn;
            barDTO.Latitude = bar.Latitude;
            barDTO.Longitude = bar.Longitude;
            //if (bar.BarReviews.Count>0)
            if (bar.BarReviews != null)
            {
                barDTO.BarReviews = bar.BarReviews
                            .Select(br=>br.BarMapReviewDTO())
                            .ToList();
            }
            barDTO.Address = bar.Address;

            return barDTO;
        }
        public static Bar BarDTOMapToModel(this BarDTO barDTO)
        {
            var bar = new Bar();
            bar.Name = barDTO.Name;
            bar.Phone = barDTO.Phone;
            bar.Website = barDTO.Website;
            bar.Description = barDTO.Description;
            bar.Address = barDTO.Address;
            bar.CityId = barDTO.CityId;
            bar.Latitude = barDTO.Latitude;
            bar.Longitude = barDTO.Longitude;

            return bar;
        }
    }
}
