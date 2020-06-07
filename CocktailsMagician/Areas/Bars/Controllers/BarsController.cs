﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CocktailsMagician.Data;
using CocktailsMagician.Data.Entities;
using CocktailsMagician.Services.Contracts;
using CocktailsMagician.Mappers;
using CocktailsMagician.Areas.Bars.Models;
using X.PagedList;
using CocktailsMagician.Areas.Cocktails.Models;
using Microsoft.AspNetCore.Identity;
using CocktailsMagician.Helpers;

namespace CocktailsMagician.Areas.Bars.Controllers
{
    [Area("Bars")]
    public class BarsController : Controller
    {
        private readonly CMContext _context;
        private readonly IBarService barService;
        private readonly ICocktailService cocktailService;
        private readonly UserManager<User> userManager;

        public BarsController(CMContext context, IBarService barService, ICocktailService cocktailService, UserManager<User> userManager)
        {
            _context = context;
            this.barService = barService;
            this.cocktailService = cocktailService;
            this.userManager = userManager;
        }

        // GET: Bars/Bars
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.RatingSortParm = sortOrder == "rating" ? "rating_desc" : "rating";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            ViewData["imgPath"] = ImagesPath.ImgsPath;

            var barDTOs = await barService.GetBarsFiltered(sortOrder, searchString);


            var barsVMs = barDTOs.Select(b => b.BarDTOtoVM());

            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View(barsVMs.ToPagedList(pageNumber, pageSize));
        }

        // GET: Bars/Bars/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barDTO = await barService.GetBarAsync((Guid)id);
            if (barDTO == null)
            {
                return NotFound();
            }
            var barVM = barDTO.BarDTOtoVM();

            var user = await userManager.GetUserAsync(HttpContext.User);
            ViewData["User"] = user;
            ViewData["imgPath"] = ImagesPath.ImgsPath;
            ViewData["Latitude"] = barVM.Latitude;
            ViewData["Longitude"] = barVM.Longitude;


            foreach (var br in barVM.BarReviews)
            {
                if (br.BarReviewLikes.Count > 0)
                {
                    var likesCount = br.BarReviewLikes.Where(brl => brl.IsLiked == true).Count();
                    br.LikesCount = likesCount;
                    if (user != null)
                    {
                        var isLiked = br.BarReviewLikes
                        .Any(brl => brl.UserId == user.Id && brl.IsLiked == true);
                        br.isLiked = isLiked;
                    }
                }
            }

            return View(barVM);
        }

        public async Task<IActionResult> BarLocation(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var barDTO = await barService.GetBarAsync((Guid)id);

            if (barDTO == null)
            {
                return NotFound();
            }

            var barVM = barDTO.BarDTOtoVM();

            ViewData["Latitude"] = barVM.Latitude;
            ViewData["Longitude"] = barVM.Longitude;

            return View();
        }

        // GET: Bars/Bars/Create
        public IActionResult Create()
        {
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name");
            return View();
        }

        // POST: Bars/Bars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Phone,Website,Description,Address,CityId")] BarViewModel barVM)
        {
            if (ModelState.IsValid)
            {
                var barDTO = barVM.BarVMtoDTO();
                var barDTOWithLocation = await barService.ParseApiLocationResult(barDTO);
                try
                {
                    var newBarDTO = await barService.CreateBarAsync(barDTOWithLocation);
                    var newBarVM = newBarDTO.BarDTOtoVM();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return View(barVM);
        }

        // GET: Bars/Bars/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barDTO = await barService.GetBarAsync((Guid)id);
            if (barDTO == null)
            {
                return NotFound();
            }

            var barVM = barDTO.BarDTOtoVM();
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name");
            return View(barVM);
        }

        // POST: Bars/Bars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(/*Guid id, */[Bind("Id,Name,Phone,Website,Description,Address,CityId")] BarViewModel barVM)
        {
            //if (id != bar.Id)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                var barDTO = barVM.BarVMtoDTO();
                var barDTOWithLocation = await barService.ParseApiLocationResult(barDTO);
                await barService.UpdateBarAsync(barDTOWithLocation);
                return RedirectToAction(nameof(Index));
            }
            //ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", bar.CityId);

            return View(barVM);
        }

        // GET: Bars/Bars/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barDTO = await barService.GetBarAsync((Guid)id);
            if (barDTO == null)
            {
                return NotFound();
            }

            var barVM = barDTO.BarDTOtoVM();

            return View(barVM);
        }

        // POST: Bars/Bars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            barService.DeleteBarAsync(id);

            return RedirectToAction(nameof(Index));
        }

        private bool BarExists(Guid id)
        {
            return _context.Bars.Any(e => e.Id == id);
        }

        public async Task<IActionResult> AddRmvCocktailsFromBar(Guid Id, string sortOrder, string currentFilter, string searchString, int? page)
        {
            var bar = await barService.GetBarAsync(Id);
            //var barVM = bar.BarDTOtoVM();
            if (bar == null)
            {
                throw new ArgumentNullException();
            }
            ViewData["barId"] = bar.Id;
            ViewData["barName"] = bar.Name;

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.RatingSortParm = sortOrder == "rating" ? "rating_desc" : "rating";

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

            //var cocktailsDTO = await cocktailService.GetAllCocktails();
            //var cocktailsVM = cocktailsDTO.Select(c => c.CocktailDTOMapToVM()).ToList();

            foreach (var cocktail in cocktailsVM)
            {
                cocktail.IsAvailableInBar = await cocktailService.IsCocktailAvailableInBar(Id, cocktail.Id);
            }

            //var cocktailsVM = cocktailsVM.Select(c => c.IsAvailableInBar = cocktailService.)

            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View(cocktailsVM.ToPagedList(pageNumber, pageSize));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRmvCocktailsFromBar(Guid Id, List<CocktailViewModel> cocktails)
        {
            foreach (var cocktail in cocktails)
            {
                if (cocktail.IsAvailableInBar)
                {
                    await barService.AddCocktailToBarAsync(Id, cocktail.Id);
                }
                else
                {
                    await barService.RemoveCocktailFromBarAsync(Id, cocktail.Id);
                }
            }
            //return RedirectToActionResult("AddRmvCocktailsFromBar", new { Id = Id, sortOrder = null, currentFilter = null, searchString = null, page = null });
            //sortOrder, string currentFilter, string searchString, int? page
            return RedirectToAction("AddRmvCocktailsFromBar");
        }

        [HttpPost]
        //[ValidateAntiForgeryToken] //TODO
        public async Task<IActionResult> AddRmvCocktailsFromBarSingle(Guid barId, Guid cocktailId, bool isAvailable)
        {
            if (isAvailable)
            {
                await barService.AddCocktailToBarAsync(barId, cocktailId);
            }
            else
            {
                await barService.RemoveCocktailFromBarAsync(barId, cocktailId);
            }
            return RedirectToAction("AddRmvCocktailsFromBar");
        }
    }
}
