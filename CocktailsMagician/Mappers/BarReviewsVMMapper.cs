using CocktailsMagician.Areas.Bars.Models;
using CocktailsMagician.Services.DTO_s;

namespace CocktailsMagician.Mappers
{
    public static class BarReviewsVMMapper
    {
        public static BarReviewViewModel BarReviewsDTOMapToVM(this BarReviewDTO barReviewDTO)
        {
            var barReviewVM = new BarReviewViewModel();
            barReviewVM.Id = barReviewDTO.Id;
            barReviewVM.BarId = barReviewDTO.BarId;
            barReviewVM.UserId = barReviewDTO.UserId;
            barReviewVM.Rating = barReviewDTO.Rating;
            barReviewVM.Comment = barReviewDTO.Comment;
            barReviewVM.ReviewedOn = barReviewDTO.ReviewedOn;
            barReviewVM.BarName = barReviewDTO.BarName;
            barReviewVM.UserName = barReviewDTO.UserName;
            barReviewVM.BarReviewLikes = barReviewDTO.BarReviewLikes;

            return barReviewVM;
        }
    }
}
