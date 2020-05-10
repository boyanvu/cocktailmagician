using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailsMagician.Data.Entities
{
    public class Cocktail
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? UnlistedOn { get; set; }
        public double AvgRating { get; set; }
        public ICollection<CocktailReview> CocktailReviews { get; set; }
    }
}
