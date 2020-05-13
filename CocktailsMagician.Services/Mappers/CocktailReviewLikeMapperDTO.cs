using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailsMagician.Services.Mappers
{
    public static class CocktailReviewLikeMapperDTO
    {
        public static CocktailReviewLikeDTO CocktailReviewLikeMapToDTO(this CocktailReviewLike cocktailReviewLike)
        {
            var cocktailReviewLikeDTO = new CocktailReviewLikeDTO();
            cocktailReviewLikeDTO.CocktailReviewId = cocktailReviewLike.CocktailReviewId;
            cocktailReviewLikeDTO.CocktailReview = cocktailReviewLike.CocktailReview;
            cocktailReviewLikeDTO.UserId = cocktailReviewLike.UserId;
            cocktailReviewLikeDTO.User = cocktailReviewLike.User;
            cocktailReviewLikeDTO.IsLiked = cocktailReviewLike.IsLiked;
            cocktailReviewLikeDTO.IsInappropriate = cocktailReviewLike.IsInappropriate;


            return cocktailReviewLikeDTO;

        }
    }
}
