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
    public class SnowboardsController : Controller
    {
        private readonly SkiShopMDContext _context;

        public SnowboardsController(SkiShopMDContext context)
        {
            _context = context;
        }

        // GET: Snowboards
        public async Task<IActionResult> Index()
        {
            return View(await _context.Snowboards.ToListAsync());
        }

        // GET: Snowboards/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snowboards = await _context.Snowboards
                .FirstOrDefaultAsync(m => m.SnowboardsId == id);
            if (snowboards == null)
            {
                return NotFound();
            }

            return View(snowboards);
        }

        // GET: Snowboards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Snowboards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SnowboardsId,Products,Model,Lenght,Price,Quantity,CratedDate")] Snowboards snowboards)
        {
            if (ModelState.IsValid)
            {
                _context.Add(snowboards);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(snowboards);
        }

        // GET: Snowboards/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snowboards = await _context.Snowboards.FindAsync(id);
            if (snowboards == null)
            {
                return NotFound();
            }
            return View(snowboards);
        }

        // POST: Snowboards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("SnowboardsId,Products,Model,Lenght,Price,Quantity,CratedDate")] Snowboards snowboards)
        {
            if (id != snowboards.SnowboardsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(snowboards);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SnowboardsExists(snowboards.SnowboardsId))
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
            return View(snowboards);
        }

        // GET: Snowboards/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snowboards = await _context.Snowboards
                .FirstOrDefaultAsync(m => m.SnowboardsId == id);
            if (snowboards == null)
            {
                return NotFound();
            }

            return View(snowboards);
        }

        // POST: Snowboards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var snowboards = await _context.Snowboards.FindAsync(id);
            _context.Snowboards.Remove(snowboards);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SnowboardsExists(long id)
        {
            return _context.Snowboards.Any(e => e.SnowboardsId == id);
        }
    }
}
