using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CocktailsMagician.Data;
using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace CocktailsMagician.Areas.Cocktails.Controllers
{
    [Area("Cocktails")]
    public class CocktailReviewsController : Controller
    {
        private readonly ICocktailService cocktailService;
        private readonly IIngredientService ingredientService;   
        private readonly ICocktailReviewService cocktailReviewService;
        private readonly ICocktailReviewLikeService cocktailReviewLikeService;
        private readonly UserManager<User> _userManager;
        private readonly IToastNotification _toastNotification;

        public CocktailReviewsController(ICocktailService cocktailService, IIngredientService ingredientService,
            ICocktailReviewService cocktailReviewService, UserManager<User> userManager, IToastNotification toastNotification,
            ICocktailReviewLikeService cocktailReviewLikeService)
        {
            this.cocktailService = cocktailService;
            this.ingredientService = ingredientService;
            this.cocktailReviewService = cocktailReviewService;
            this.cocktailReviewLikeService = cocktailReviewLikeService;
            this._userManager = userManager;
            this._toastNotification = toastNotification;     
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddReview(IFormCollection form)
        {
            var review = form["Review"].ToString();
            var cocktailId = Guid.Parse(form["CocktailId"]);
            var rating = int.Parse(form["Rating"]);

            var cocktail = await cocktailService.GetCocktail(cocktailId);
            var user = await _userManager.GetUserAsync(HttpContext.User);


            await cocktailReviewService.CreateCocktailReview(cocktail.Name, user.UserName, rating, review);
            _toastNotification.AddSuccessToastMessage("Review made successfully!");

            return RedirectToAction("Details", "Cocktails", new { id = cocktailId });
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> LikeReview(Guid cocktailReviewId, bool isLiked)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            //var allCocktailReviewLikes = await cocktailReviewLikeService.GetAllCocktailReviewLikes();
            //var cocktailReviewLike = allCocktailReviewLikes
            //    .FirstOrDefault(cr => cr.CocktailReviewId == cocktailReviewId);
            ////var cocktailId = cocktailReviewLike.CocktailReview.CocktailId;
              
            if (isLiked)
            {
                await cocktailReviewLikeService.AddCocktailReviewLike(cocktailReviewId, user.UserName);
                _toastNotification.AddSuccessToastMessage("Review liked!");
            }
            else 
            {
                await cocktailReviewLikeService.RemoveCocktailReviewLike(cocktailReviewId, user.UserName);
                _toastNotification.AddSuccessToastMessage("Review disliked!");
            }

            return RedirectToAction("Index", "Cocktails"/*, new { id = cocktailId }*/);
        }
    }
}