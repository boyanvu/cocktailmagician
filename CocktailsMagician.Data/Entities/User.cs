using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailsMagician.Data.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string  Username { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DeletedOn { get; set; }
        public ICollection<BarReview> BarReviews { get; set; }
        public ICollection<BarReviewLike> BarReviewLikes { get; set; }
        public ICollection<CocktailReview> CocktailReviews { get; set; }
        public ICollection<CocktailReviewLike> CocktailReviewLikes { get; set; }
    }
}
