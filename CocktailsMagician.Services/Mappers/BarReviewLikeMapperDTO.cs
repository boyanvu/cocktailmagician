using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailsMagician.Services.Mappers
{
    public static class BarReviewLikeMapperDTO
    {
        public static BarReviewLikeDTO BarMapReviewLikeDTO(this BarReviewLike barReviewLike)
        {
            var barReviewLikeDTO = new BarReviewLikeDTO();
            barReviewLikeDTO.BarReviewId = barReviewLike.BarReviewId;
            barReviewLikeDTO.BarReview = barReviewLike.BarReview;
            barReviewLikeDTO.UserId = barReviewLike.UserId;
            barReviewLikeDTO.User = barReviewLike.User;
            barReviewLikeDTO.IsLiked = barReviewLike.IsLiked;
            barReviewLikeDTO.IsInappropriate = barReviewLike.IsInappropriate;


            return barReviewLikeDTO;

        }
    }
}
