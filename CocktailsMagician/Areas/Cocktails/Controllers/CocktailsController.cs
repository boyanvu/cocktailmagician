using System;
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
using CocktailsMagician.Areas.Cocktails.Models;
using CocktailsMagician.Services.DTO_s;
using X.PagedList;
using CocktailsMagician.Areas.Ingredients.Models;

namespace CocktailsMagician.Areas.Cocktails.Controllers
{
    [Area("Cocktails")]
    public class CocktailsController : Controller
    {
        private readonly CMContext _context;
        private readonly ICocktailService cocktailService;
        private readonly IIngredientService ingredientService;

        public CocktailsController(CMContext context, ICocktailService cocktailService, IIngredientService ingredientService)
        {
            _context = context;
            this.cocktailService = cocktailService;
            this.ingredientService = ingredientService;
        }

        // GET: Cocktails/Cocktails
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


            var cocktails = await cocktailService.GetAllCocktails(sortOrder, currentFilter, searchString, page);

            var cocktailsVM = cocktails
                .Select(c => c.CocktailDTOMapToVM())
                .ToList();


            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View(cocktailsVM.ToPagedList(pageNumber,pageSize));
        }

        // GET: Cocktails/Cocktails/Details/5
        public async Task<IActionResult> Details(Guid id)
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

         

            return View(cocktail.CocktailDTOMapToVM());
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
                return RedirectToAction(nameof(Index));
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

            if (cocktail == null)
            {
                return NotFound();
            }

            return View(cocktail.CocktailDTOMapToVM());
        }

        // POST: Cocktails/Cocktails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Description")] CocktailViewModel cocktail)
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
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CocktailExists(cocktail.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
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

            return View(cocktail.CocktailDTOMapToVM());

        }

        // POST: Cocktails/Cocktails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await cocktailService.DeleteCocktail(id);

            return RedirectToAction(nameof(Index));
        }

        private bool CocktailExists(Guid id)
        {
            return _context.Cocktails.Any(e => e.Id == id);
        }
    }
}
