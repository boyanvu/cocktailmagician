using CocktailsMagician.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
        public City City { get; set; }
        public double AvgRating { get; set; }
        public ICollection<BarReview> BarReviews { get; set; }
    }
}
