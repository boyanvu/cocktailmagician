using System;
using System.Threading.Tasks;
using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace CocktailsMagician.Areas.Cocktails.Controllers
{
    [Area("Bars")]
    public class BarReviewsController : Controller
    {
        private readonly IBarService barService;
        private readonly IBarReviewService barReviewService;
        private readonly UserManager<User> userManager;
        private readonly IToastNotification toastNotification;
        private readonly IBarReviewLikeService barReviewLikeService;

        public BarReviewsController(IBarService barService,IBarReviewService barReviewService, UserManager<User> userManager,
            IBarReviewLikeService barReviewLikeService,IToastNotification toastNotification)
        {
            this.barService = barService;
            this.barReviewService = barReviewService;
            this.userManager = userManager;
            this.toastNotification = toastNotification;
            this.barReviewLikeService = barReviewLikeService;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBarReview(IFormCollection form)
        {
            var review = form["Review"].ToString();
            //var cocktailId = Guid.Parse(form["CocktailId"]);
            var barId = Guid.Parse(form["BarId"]);
            var rating = int.Parse(form["Rating"]);

            //var cocktail = await barService.GetBarAsync(barId);
            var user = await userManager.GetUserAsync(HttpContext.User);


            await barReviewService.CreateBarReviewAsync(barId, user.Id, rating, review);
            toastNotification.AddSuccessToastMessage("Review made successfully!");

            return RedirectToAction("Details", "Bars", new { id = barId });
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> LikeReview(Guid barReviewId, bool isLiked)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);


            if (isLiked)
            {
                await barReviewLikeService.AddBarReviewLikeAsync(barReviewId, user.Id);
            }
            else
            {
                await barReviewLikeService.RemoveBarReviewLikeAsync(barReviewId, user.Id);
            }

            return RedirectToAction("Index", "Bars"/*, new { id = cocktailId }*/);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> CheckIfPostedReview(Guid barId)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            //if (barId==null || user==null)
            //{
            //    return Json(false);
            //}
            var hasAlreadyReviewed = await barReviewService.HasAlreadyReviewedAsync(barId, user.Id);

            return Json(hasAlreadyReviewed);
        }
    }
}