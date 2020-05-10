using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailsMagician.Data.Entities
{
    public class CocktailReviewLike
    {
        public Guid CocktailId { get; set; }
        public Cocktail Cocktail { get; set; }
        public Guid UserReviewId { get; set; }
        public User UserReview { get; set; }

        public Guid UserLikeId { get; set; }
        public User UserLike { get; set; }
        public bool IsInappropriate { get; set; }
    }
}
