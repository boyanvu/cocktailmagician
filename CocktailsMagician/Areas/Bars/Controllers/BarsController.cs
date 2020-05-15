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
using CocktailsMagician.Areas.Bars.Models;
using X.PagedList;

namespace CocktailsMagician.Areas.Bars.Controllers
{
    [Area("Bars")]
    public class BarsController : Controller
    {
        private readonly CMContext _context;
        private readonly IBarService barService;

        public BarsController(CMContext context, IBarService barService)
        {
            _context = context;
            this.barService = barService;
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


            var barDTOs = await barService.GetAllBars(sortOrder, searchString);


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
            return View(barVM);
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
                try
                {
                    var newBarDTO = await barService.CreateBarAsync(barDTO);
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
                await barService.UpdateBarAsync(barVM.BarVMtoDTO());
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
    }
}
