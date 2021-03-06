﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CocktailsMagician.Data;
using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services.Contracts;
using CocktailsMagician.Mappers;
using CocktailsMagician.Areas.Cocktails.Models;
using CocktailsMagician.Services.DTO_s;
using X.PagedList;
using CocktailsMagician.Areas.Ingredients.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using NToastNotify;
using CocktailsMagician.Helpers;

namespace CocktailsMagician.Areas.Cocktails.Controllers
{
    [Area("Cocktails")]
    public class CocktailsController : Controller
    {
        private readonly ICocktailService cocktailService;
        private readonly IIngredientService ingredientService;
        private readonly UserManager<User> _userManager;
        private readonly ICocktailReviewService cocktailReviewService;
        private readonly IToastNotification _toastNotification;
        private readonly ICocktailReviewLikeService cocktailReviewLikeService;

        public CocktailsController(ICocktailService cocktailService, IIngredientService ingredientService,
            ICocktailReviewService cocktailReviewService, UserManager<User> userManager, IToastNotification toastNotification,
            ICocktailReviewLikeService cocktailReviewLikeService)
        {
            this.cocktailService = cocktailService;
            this.ingredientService = ingredientService;
            this.cocktailReviewService = cocktailReviewService;
            this._userManager = userManager;
            this._toastNotification = toastNotification;
            this.cocktailReviewLikeService = cocktailReviewLikeService;
        }

        // GET: Cocktails/Cocktails
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.RatingSortParm = sortOrder == "rating" ? "rating_desc" : "rating";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var cocktails = await cocktailService.GetAllCocktails(sortOrder, searchString);

            var cocktailsVM = cocktails
                .Select(c => c.CocktailDTOMapToVM())
                .ToList();

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            ViewData["imgPath"] = ImagesPath.ImgsPath;

            return View(cocktailsVM.ToPagedList(pageNumber, pageSize));
        }

        // GET: Cocktails/Cocktails/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cocktail = await cocktailService.GetCocktail(id);
            var cocktailIngredients = await cocktailService.ShowCocktailIngredients(id);
            var cocktailIngredientsVM = cocktailIngredients
                .Select(ci => ci.CocktailIngredientDTOMapToVM());

            if (cocktail == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(HttpContext.User);

            ViewData["imgPath"] = ImagesPath.ImgsPath;
            ViewBag.CocktailId = cocktail.Id;

            var cocktailReviews = await cocktailReviewService.GetAllSpecificCocktailReviews(id);
            var cocktailReviewsVM = cocktailReviews.Select
                (cr => cr.CocktailReviewsDTOMapToVM())
                .ToList();

            if (user != null)
            {
                var cocktailReviewLikes = await this.cocktailReviewLikeService.GetAllSpecificCocktailReviewLikes(id);
                var userCRL = cocktailReviewLikes
                    .Where(crl => crl.UserId == user.Id)
                    .ToList();

                foreach (var userCRLike in userCRL)
                {
                    foreach (var cReview in cocktailReviewsVM)
                    {
                        if (userCRLike.UserId == user.Id && userCRLike.CocktailReviewId == cReview.Id)
                        {
                            cReview.IsLiked = userCRLike.IsLiked;
                        }
                    }
                }
            }

            foreach (var cReview in cocktailReviewsVM)
            {
                cReview.NumberOfLikes = await this.cocktailReviewLikeService.GetCocktailReviewNumberOfLikes(cReview.Id);
            }

            ViewBag.Reviews = cocktailReviewsVM;

            var ratings = cocktailReviewsVM;

            var cocktailVM = cocktail.CocktailDTOMapToVM();
            cocktailVM.CocktailIngredients = cocktailIngredientsVM.ToList();

            return View(cocktailVM);
        }



        // GET: Cocktails/Cocktails/Create
        public async Task<IActionResult> Create(CocktailViewModel cocktail)
        {
            var ingredients = await ingredientService.GetAllIngredients();
            var ingredientsVM = ingredients
                .Select(i => i.IngredientDTOMapToVM());
            cocktail.Ingredients = ingredientsVM.ToList();
            // var allIngredients = await ingredientsVM.ToListAsync();

            return View(cocktail);
        }

        // POST: Cocktails/Cocktails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] CocktailViewModel cocktail,
           List<IngredientViewModel> allIngredients)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    cocktail.Id = Guid.NewGuid();
                    var cocktailDTO = new CocktailDTO
                    {
                        Id = cocktail.Id,
                        Name = cocktail.Name,
                        Description = cocktail.Description
                    };

                    var newCocktail = await cocktailService.CreateCocktail(cocktailDTO);

                    foreach (var ingredient in allIngredients)
                    {
                        if (ingredient.isSelected)
                        {
                            var cocktailIngredientDTO = new CocktailIngredientsDTO
                            {
                                CocktailId = cocktail.Id,
                                IngredientId = ingredient.Id
                            };

                            await cocktailService.AddIngredientToCocktail(cocktailIngredientDTO);
                        }
                    }

                    _toastNotification.AddSuccessToastMessage($"Cocktail {newCocktail.Name} created successfully!");
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    _toastNotification.AddErrorToastMessage("Cocktail cannot be created!");
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(cocktail);
        }

        // GET: Cocktails/Cocktails/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cocktail = await cocktailService.GetCocktail(id);
            var ingredients = await ingredientService.GetAllIngredients();
            var ingredientsVM = ingredients
                .Select(i => i.IngredientDTOMapToVM());

            if (cocktail == null)
            {
                return NotFound();
            }
            var cocktailVM = cocktail.CocktailDTOMapToVM();
            cocktailVM.Ingredients = ingredientsVM.ToList();

            foreach (var ingredient in cocktailVM.Ingredients)
            {
                ingredient.isSelected = await cocktailService
                    .DoesCocktailHaveIngredient(cocktailVM.Id, ingredient.Id);
            }

            return View(cocktailVM);
        }

        // POST: Cocktails/Cocktails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Description")] CocktailViewModel cocktail,
            List<IngredientViewModel> allIngredients)
        {
            if (id != cocktail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await cocktailService.UpdateCocktail(cocktail.Id, cocktail.Name, cocktail.Description);

                    foreach (var ingredient in allIngredients)
                    {
                        if (ingredient.isSelected)
                        {
                            var isUnlisted = await cocktailService.IngredientIsUnlisted(cocktail.Id, ingredient.Id);

                            if (isUnlisted == true)
                            {
                                var existingCIDTO = await cocktailService.GetCocktailIngredient(cocktail.Id, ingredient.Id);
                                await cocktailService.AddIngredientToCocktail(existingCIDTO);
                            }
                            else
                            {
                                var existingCIDTO = await cocktailService.GetCocktailIngredient(cocktail.Id, ingredient.Id);
                                if (existingCIDTO == null)
                                {
                                    var cocktailIngredientDTO = new CocktailIngredientsDTO
                                    {
                                        CocktailId = cocktail.Id,
                                        IngredientId = ingredient.Id
                                    };
                                    await cocktailService.AddIngredientToCocktail(cocktailIngredientDTO);
                                }
                            }
                        }
                        else
                        {
                            var existingCIDTO = await cocktailService.GetCocktailIngredient(cocktail.Id, ingredient.Id);
                            if (existingCIDTO != null)
                            {
                                var isUnlisted = await cocktailService.IngredientIsUnlisted(cocktail.Id, ingredient.Id);
                                if (isUnlisted == false)
                                {
                                    await cocktailService.RemoveIngredientFromCocktail(cocktail.Id, ingredient.Id);
                                }
                            }
                        }
                    }
                }
                catch
                {
                    _toastNotification.AddErrorToastMessage("Cocktail cannot be edited!");
                    return RedirectToAction(nameof(Index));
                }

                _toastNotification.AddSuccessToastMessage($"Cocktail {cocktail.Name} edited successfully!");
                return RedirectToAction(nameof(Index));
            }
            return View(cocktail);
        }

        // GET: Cocktails/Cocktails/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cocktail = await cocktailService.GetCocktail(id);

            if (cocktail == null)
            {
                return NotFound();
            }

            var cocktailVM = cocktail.CocktailDTOMapToVM();

            return View(cocktailVM);

        }

        // POST: Cocktails/Cocktails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await cocktailService.DeleteCocktail(id);
            _toastNotification.AddSuccessToastMessage("Cocktail unlisted successfully!");

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> ListCocktailsForBar(Guid? id)
        {
            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Request.Form["start"].FirstOrDefault();
            var length = Request.Form["length"].FirstOrDefault();
            var searchValue = Request.Form["search[value]"].FirstOrDefault();
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;

            int totalCount = await this.cocktailService.GetCocktailsCount();

            int filteredCocktails = await this.cocktailService.GetCocktailsCount(id, searchValue);

            var cocktailDTOs = await this.cocktailService.GetCocktailsInBar(id.Value, skip, pageSize, searchValue, sortColumn, sortColumnDirection);

            return Json(new { draw = draw, recordsFiltered = filteredCocktails, recordsTotal = totalCount, data = cocktailDTOs.Select(cocktail => cocktail.CocktailDTOMapToVM()) });
        }
        public IActionResult GetTableView(Guid cocktailId)
        {
            return PartialView("_BarsWithCocktailsDatabale", cocktailId);
        }
    }
}
