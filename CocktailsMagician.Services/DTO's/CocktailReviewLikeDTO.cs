using CocktailsMagician.Data.Entities;
using System;

namespace CocktailsMagician.Services.DTO_s
{
    public class CocktailReviewLikeDTO
    {
        public Guid CocktailReviewId { get; set; }
        public CocktailReview CocktailReview { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        public bool IsLiked { get; set; }
        public bool IsInappropriate { get; set; }
    }
}
