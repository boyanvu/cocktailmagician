using System;

namespace CocktailsMagician.Data.Entities
{
    public class CocktailReviewLike
    {
        public Guid CocktailReviewId { get; set; }
        public CocktailReview CocktailReview { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        public bool IsLiked { get; set; }
        public bool IsInappropriate { get; set; }
    }
}
