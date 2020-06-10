using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services.DTO_s;

namespace CocktailsMagician.Services.Mappers
{
    public static class CocktailReviewMapperDTO
    {
        public static CocktailReviewDTO CocktailMapReviewDTO(this CocktailReview cocktailReview)
        {
            var cocktailReviewDTO = new CocktailReviewDTO();
            cocktailReviewDTO.Id = cocktailReview.Id;
            cocktailReviewDTO.CocktailId = cocktailReview.CocktailId;
            cocktailReviewDTO.UserId = cocktailReview.UserId;
            cocktailReviewDTO.Rating = cocktailReview.Rating;
            cocktailReviewDTO.Comment = cocktailReview.Comment;
            cocktailReviewDTO.ReviewedOn = cocktailReview.ReviewedOn;
            cocktailReviewDTO.CocktailName = cocktailReview.Cocktail.Name;
            cocktailReviewDTO.UserName = cocktailReview.User.UserName;
            cocktailReviewDTO.CocktailReviewLikes = cocktailReview.CocktailReviewLikes;


            return cocktailReviewDTO;
        }
    }
}
