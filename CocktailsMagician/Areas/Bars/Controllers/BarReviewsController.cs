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

        public BarReviewsController(IBarService barService,
            IBarReviewService barReviewService, UserManager<User> userManager, IToastNotification toastNotification)
        {
            this.barService = barService;
            this.barReviewService = barReviewService;
            this.userManager = userManager;
            this.toastNotification = toastNotification;
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
    }
}