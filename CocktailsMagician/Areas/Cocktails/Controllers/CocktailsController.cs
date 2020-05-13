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

namespace CocktailsMagician.Areas.Cocktails.Controllers
{
    [Area("Cocktails")]
    public class CocktailsController : Controller
    {
        private readonly CMContext _context;
        private readonly ICocktailService cocktailService;

        public CocktailsController(CMContext context, ICocktailService cocktailService)
        {
            _context = context;
            this.cocktailService = cocktailService;
        }

        // GET: Cocktails/Cocktails
        public async Task<IActionResult> Index()
        {
            var cocktails = await cocktailService.GetAllCocktails();

            var cocktailsVM = cocktails
                .Where(c => c.UnlistedOn == null)
                .Select(c => c.CocktailDTOMapToVM())
                .ToList();
                
            return View(cocktailsVM);
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

            var cocktailVM = cocktail.CocktailDTOMapToVM();

            return View(cocktailVM);
        }

        // GET: Cocktails/Cocktails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cocktails/Cocktails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] CocktailViewModel cocktail)
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

            var cocktailVM = cocktail.CocktailDTOMapToVM();

            return View(cocktailVM);

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
