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
    public class BootsController : Controller
    {
        private readonly SkiShopMDContext _context;

        public BootsController(SkiShopMDContext context)
        {
            _context = context;
        }

        // GET: Boots
        public async Task<IActionResult> Index()
        {
            return View(await _context.Boots.ToListAsync());
        }

        // GET: Boots/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boots = await _context.Boots
                .FirstOrDefaultAsync(m => m.BootsId == id);
            if (boots == null)
            {
                return NotFound();
            }

            return View(boots);
        }

        // GET: Boots/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Boots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BootsId,Producer,Model,Size,Price,Quantity,CratedDate")] Boots boots)
        {
            if (ModelState.IsValid)
            {
                _context.Add(boots);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(boots);
        }

        // GET: Boots/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boots = await _context.Boots.FindAsync(id);
            if (boots == null)
            {
                return NotFound();
            }
            return View(boots);
        }

        // POST: Boots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("BootsId,Producer,Model,Size,Price,Quantity,CratedDate")] Boots boots)
        {
            if (id != boots.BootsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boots);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BootsExists(boots.BootsId))
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
            return View(boots);
        }

        // GET: Boots/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boots = await _context.Boots
                .FirstOrDefaultAsync(m => m.BootsId == id);
            if (boots == null)
            {
                return NotFound();
            }

            return View(boots);
        }

        // POST: Boots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var boots = await _context.Boots.FindAsync(id);
            _context.Boots.Remove(boots);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BootsExists(long id)
        {
            return _context.Boots.Any(e => e.BootsId == id);
        }
    }
}
