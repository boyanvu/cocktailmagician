using CocktailsMagician.Areas.Cocktails.Models;
using CocktailsMagician.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailsMagician.Mappers
{
    public static class CocktailReviewsVMMapper
    {
        public static CocktailReviewViewModel CocktailReviewsDTOMapToVM(this CocktailReviewDTO cocktailReviewDTO)
        {
            var cocktailReview = new CocktailReviewViewModel();

            cocktailReview.Id = cocktailReviewDTO.Id;
            cocktailReview.Rating = cocktailReviewDTO.Rating;
            cocktailReview.Comment = cocktailReviewDTO.Comment;
            cocktailReview.CocktailId = cocktailReviewDTO.CocktailId;
            cocktailReview.UserId = cocktailReviewDTO.UserId;
            cocktailReview.UserName = cocktailReviewDTO.UserName;
            cocktailReview.ReviewedOn = cocktailReviewDTO.ReviewedOn;

            return cocktailReview;
        }
    }
}
