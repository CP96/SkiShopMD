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
    public class SkisController : Controller
    {
        private readonly SkiShopMDContext _context;

        public SkisController(SkiShopMDContext context)
        {
            _context = context;
        }

        // GET: Skis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Skis.ToListAsync());
        }

        // GET: Skis/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skis = await _context.Skis
                .FirstOrDefaultAsync(m => m.SkisId == id);
            if (skis == null)
            {
                return NotFound();
            }

            return View(skis);
        }

        // GET: Skis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Skis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SkisId,Producer,Model,Lenght,Price,Quantity,CratedDate")] Skis skis)
        {
            if (ModelState.IsValid)
            {
                _context.Add(skis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(skis);
        }

        // GET: Skis/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skis = await _context.Skis.FindAsync(id);
            if (skis == null)
            {
                return NotFound();
            }
            return View(skis);
        }

        // POST: Skis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("SkisId,Producer,Model,Lenght,Price,Quantity,CratedDate")] Skis skis)
        {
            if (id != skis.SkisId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(skis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkisExists(skis.SkisId))
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
            return View(skis);
        }

        // GET: Skis/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skis = await _context.Skis
                .FirstOrDefaultAsync(m => m.SkisId == id);
            if (skis == null)
            {
                return NotFound();
            }

            return View(skis);
        }

        // POST: Skis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var skis = await _context.Skis.FindAsync(id);
            _context.Skis.Remove(skis);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SkisExists(long id)
        {
            return _context.Skis.Any(e => e.SkisId == id);
        }
    }
}
