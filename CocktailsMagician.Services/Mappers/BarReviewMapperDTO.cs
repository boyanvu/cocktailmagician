using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailsMagician.Services.Mappers
{
    public static class BarReviewMapperDTO
    {
        public static BarReviewDTO BarMapReviewDTO(this BarReview barReview)
        {
            var barReviewDTO = new BarReviewDTO();
            barReviewDTO.BarId = barReview.BarId;
            barReviewDTO.UserId = barReview.UserId;
            barReviewDTO.Rating = barReview.Rating;
            barReviewDTO.Comment = barReview.Comment;
            barReviewDTO.ReviewedOn = barReview.ReviewedOn;
            barReviewDTO.BarName = barReview.Bar.Name;
            barReviewDTO.UserName = barReview.User.UserName;
            barReviewDTO.BarReviewLikes = barReview.BarReviewLikes;

            return barReviewDTO;
        }

        public static BarReview BarReviewDTOMapToModel(this BarReviewDTO barReviewDTO)
        {
            var barReview = new BarReview();
            barReview.BarId = barReviewDTO.BarId;
            barReview.UserId = barReviewDTO.UserId;
            barReview.Rating = barReviewDTO.Rating;
            barReview.Comment = barReviewDTO.Comment;
            barReview.ReviewedOn = DateTime.UtcNow;

            return barReview;
        }
    }
}
