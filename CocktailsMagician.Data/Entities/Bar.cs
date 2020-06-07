using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailsMagician.Data.Entities
{
    public class Bar
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
        public DateTime? UnlistedOn { get; set; }
        public string Address { get; set; }
        public Guid CityId { get; set; }
        public City City { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double AvgRating { get; set; }
        public ICollection<BarReview> BarReviews { get; set; }
    }
}
