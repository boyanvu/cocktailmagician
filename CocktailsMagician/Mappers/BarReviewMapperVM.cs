using CocktailsMagician.Areas.BarReviews.Models;
using CocktailsMagician.Services.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailsMagician.Mappers
{
    public static class BarReviewMapperVM
    {
        public static BarReviewViewModel BarReviewDTOtoVM(this BarReviewDTO barReviewDTO)
        {
            var barReviewVM = new BarReviewViewModel();
            barReviewVM.BarId = barReviewDTO.BarId;
            barReviewVM.BarName = barReviewDTO.BarName;
            barReviewVM.UserId = barReviewDTO.UserId;
            barReviewVM.UserName = barReviewDTO.UserName;
            barReviewVM.Rating = barReviewDTO.Rating;
            barReviewVM.Comment = barReviewDTO.Comment;
            barReviewVM.DeletedOn = barReviewDTO.DeletedOn;
            barReviewVM.ReviewedOn = barReviewDTO.ReviewedOn;
            return barReviewVM;
        }

    }
}
