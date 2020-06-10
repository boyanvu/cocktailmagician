using System;
using System.Collections.Generic;

namespace CocktailsMagician.Services.DTO_s
{
    public class BarDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
        public DateTime? UnlistedOn { get; set; }
        public Guid CityId { get; set; }
        public string City { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public bool isLiked { get; set; }
        public double AvgRating { get; set; }
        public string Address { get; set; }
        public IList<BarReviewDTO> BarReviews { get; set; }
    }
}
