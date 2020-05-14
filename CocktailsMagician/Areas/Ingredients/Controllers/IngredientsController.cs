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
using CocktailsMagician.Areas.Ingredients.Models;
using CocktailsMagician.Services.DTO_s;

namespace CocktailsMagician.Areas.Ingredients.Controllers
{
    [Area("Ingredients")]
    public class IngredientsController : Controller
    {
        private readonly CMContext _context;
        private readonly IIngredientService ingredientService;

        public IngredientsController(CMContext context, IIngredientService ingredientService)
        {
            _context = context;
            this.ingredientService = ingredientService;
        }

        // GET: Ingredients/Ingredients
        public async Task<IActionResult> Index()
        {
            var ingredients = await ingredientService.GetAllIngredients();

            var ingredientsVM = ingredients
                .Where(i => i.UnlistedOn == null)
                .Select(i => i.IngredientDTOMapToVM())
                .ToList();

            return View(ingredientsVM);
        }

        // GET: Ingredients/Ingredients/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = await ingredientService.GetIngredient(id);

            if (ingredient == null)
            {
                return NotFound();
            }

            return View(ingredient.IngredientDTOMapToVM());
        }

        // GET: Ingredients/Ingredients/Create
        public IActionResult Create()
        {
            ViewData["TypeId"] = new SelectList(_context.IngredientTypes, "Id", "Name");
            return View();
        }

        // POST: Ingredients/Ingredients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Abv,Description,UnlistedOn,TypeId")] IngredientViewModel ingredient)
        {
            if (ModelState.IsValid)
            {
                ingredient.Id = Guid.NewGuid();

                var ingredientDTO = new IngredientDTO
                {
                    Id = ingredient.Id,
                    Name = ingredient.Name,
                    Description = ingredient.Description,
                    Abv = ingredient.Abv,
                    TypeId = ingredient.TypeId
                };

                var newIngredient = await ingredientService.CreateIngredient(ingredientDTO);

                return RedirectToAction(nameof(Index));
            }

            ViewData["TypeId"] = new SelectList(_context.IngredientTypes, "Id", "Name", ingredient.TypeId);

            return View(ingredient);
        }

        // GET: Ingredients/Ingredients/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = await ingredientService.GetIngredient(id);

            if (ingredient == null)
            {
                return NotFound();
            }

            ViewData["TypeId"] = new SelectList(_context.IngredientTypes, "Id", "Name", ingredient.TypeId);

            return View(ingredient.IngredientDTOMapToVM());
        }

        // POST: Ingredients/Ingredients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Abv,Description,TypeId")] IngredientViewModel ingredient)
        {
            if (id != ingredient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await ingredientService.UpdateIngredient(ingredient.Id, ingredient.Name,
                        ingredient.Abv, ingredient.Description, ingredient.TypeId);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngredientExists(ingredient.Id))
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

            ViewData["TypeId"] = new SelectList(_context.IngredientTypes, "Id", "Name", ingredient.TypeId);
            return View(ingredient);
        }

        // GET: Ingredients/Ingredients/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = await ingredientService.GetIngredient(id);

            if (ingredient == null)
            {
                return NotFound();
            }

            return View(ingredient.IngredientDTOMapToVM());
        }

        // POST: Ingredients/Ingredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await ingredientService.DeleteIngredient(id);

            return RedirectToAction(nameof(Index));
        }

        private bool IngredientExists(Guid id)
        {
            return _context.Ingredients.Any(e => e.Id == id);
        }
    }
}
