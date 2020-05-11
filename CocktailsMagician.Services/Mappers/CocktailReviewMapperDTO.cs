using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailsMagician.Services.Mappers
{
    public static class CocktailReviewMapperDTO
    {
        public static CocktailReviewDTO CocktailMapReviewDTO(this CocktailReview cocktailReview)
        {
            var cocktailReviewDTO = new CocktailReviewDTO();
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
