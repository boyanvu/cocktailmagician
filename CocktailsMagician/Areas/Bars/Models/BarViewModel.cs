using CocktailsMagician.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailsMagician.Areas.Bars.Models
{
    public class BarViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
        public DateTime? UnlistedOn { get; set; }
        public string Address { get; set; }
        public Guid CityId { get; set; }
        public string City { get; set; }
        public double AvgRating { get; set; }
        public List<BarReview> BarReviews { get; set; } = new List<BarReview>();
    }
}
