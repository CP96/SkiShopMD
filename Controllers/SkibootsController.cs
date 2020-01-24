using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SkiShopMD.Models;

namespace SkiShopMD.Controllers
{
    public class SkibootsController : Controller
    {
        private readonly SkiShopMDContext _context;

        public SkibootsController(SkiShopMDContext context)
        {
            _context = context;
        }

        // GET: Skiboots
        public async Task<IActionResult> Index()
        {
            return View(await _context.Skiboots.ToListAsync());
        }

        // GET: Skiboots/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skiboots = await _context.Skiboots
                .FirstOrDefaultAsync(m => m.SkinootsId == id);
            if (skiboots == null)
            {
                return NotFound();
            }

            return View(skiboots);
        }

        // GET: Skiboots/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Skiboots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SkinootsId,Producer,Model,Size,Price,Quantity,CratedDate")] Skiboots skiboots)
        {
            if (ModelState.IsValid)
            {
                _context.Add(skiboots);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(skiboots);
        }

        // GET: Skiboots/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skiboots = await _context.Skiboots.FindAsync(id);
            if (skiboots == null)
            {
                return NotFound();
            }
            return View(skiboots);
        }

        // POST: Skiboots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("SkinootsId,Producer,Model,Size,Price,Quantity,CratedDate")] Skiboots skiboots)
        {
            if (id != skiboots.SkinootsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(skiboots);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkibootsExists(skiboots.SkinootsId))
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
            return View(skiboots);
        }

        // GET: Skiboots/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skiboots = await _context.Skiboots
                .FirstOrDefaultAsync(m => m.SkinootsId == id);
            if (skiboots == null)
            {
                return NotFound();
            }

            return View(skiboots);
        }

        // POST: Skiboots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var skiboots = await _context.Skiboots.FindAsync(id);
            _context.Skiboots.Remove(skiboots);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SkibootsExists(long id)
        {
            return _context.Skiboots.Any(e => e.SkinootsId == id);
        }
    }
}
