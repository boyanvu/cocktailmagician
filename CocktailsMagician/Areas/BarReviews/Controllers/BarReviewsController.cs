using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CocktailsMagician.Data;
using CocktailsMagician.Data.Entities;

namespace CocktailsMagician.Areas.BarReviews.Controllers
{
    [Area("BarReviews")]
    public class BarReviewsController : Controller
    {
        private readonly CMContext _context;

        public BarReviewsController(CMContext context)
        {
            _context = context;
        }

        // GET: BarReviews/BarReviews
        public async Task<IActionResult> Index()
        {
            var cMContext = _context.BarReviews.Include(b => b.Bar).Include(b => b.User);
            return View(await cMContext.ToListAsync());
        }

        // GET: BarReviews/BarReviews/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barReview = await _context.BarReviews
                .Include(b => b.Bar)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (barReview == null)
            {
                return NotFound();
            }

            return View(barReview);
        }

        // GET: BarReviews/BarReviews/Create
        public IActionResult Create()
        {
            ViewData["BarId"] = new SelectList(_context.Bars, "Id", "Address");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email");
            return View();
        }

        // POST: BarReviews/BarReviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BarId,UserId,Rating,Comment,DeletedOn,ReviewedOn")] BarReview barReview)
        {
            if (ModelState.IsValid)
            {
                barReview.Id = Guid.NewGuid();
                _context.Add(barReview);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BarId"] = new SelectList(_context.Bars, "Id", "Address", barReview.BarId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", barReview.UserId);
            return View(barReview);
        }

        // GET: BarReviews/BarReviews/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barReview = await _context.BarReviews.FindAsync(id);
            if (barReview == null)
            {
                return NotFound();
            }
            ViewData["BarId"] = new SelectList(_context.Bars, "Id", "Address", barReview.BarId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", barReview.UserId);
            return View(barReview);
        }

        // POST: BarReviews/BarReviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,BarId,UserId,Rating,Comment,DeletedOn,ReviewedOn")] BarReview barReview)
        {
            if (id != barReview.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(barReview);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BarReviewExists(barReview.Id))
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
            ViewData["BarId"] = new SelectList(_context.Bars, "Id", "Address", barReview.BarId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", barReview.UserId);
            return View(barReview);
        }

        // GET: BarReviews/BarReviews/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barReview = await _context.BarReviews
                .Include(b => b.Bar)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (barReview == null)
            {
                return NotFound();
            }

            return View(barReview);
        }

        // POST: BarReviews/BarReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var barReview = await _context.BarReviews.FindAsync(id);
            _context.BarReviews.Remove(barReview);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BarReviewExists(Guid id)
        {
            return _context.BarReviews.Any(e => e.Id == id);
        }
    }
}
