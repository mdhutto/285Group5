using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RisingPhoenix.Models;

namespace RisingPhoenix.Controllers
{
    public class HtmoneysController : Controller
    {
        private readonly RisingPhoenixDBContext _context;

        public HtmoneysController(RisingPhoenixDBContext context)
        {
            _context = context;
        }

        // GET: Htmoneys
        public async Task<IActionResult> Index()
        {
            var risingPhoenixDBContext = _context.Htmoneys.Include(h => h.Form).Include(h => h.RefForm);
            return View(await risingPhoenixDBContext.ToListAsync());
        }

        // GET: Htmoneys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var htmoneys = await _context.Htmoneys
                .Include(h => h.Form)
                .Include(h => h.RefForm)
                .SingleOrDefaultAsync(m => m.FormId == id);
            if (htmoneys == null)
            {
                return NotFound();
            }

            return View(htmoneys);
        }

        // GET: Htmoneys/Create
        public IActionResult Create()
        {
            ViewData["FormId"] = new SelectList(_context.Forms, "FormId", "FormId");
            ViewData["RefFormId"] = new SelectList(_context.Referrals, "FormId", "FormId");
            return View();
        }

        // POST: Htmoneys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FormId,RefFormId,Income")] Htmoneys htmoneys)
        {
            if (ModelState.IsValid)
            {
                _context.Add(htmoneys);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FormId"] = new SelectList(_context.Forms, "FormId", "FormId", htmoneys.FormId);
            ViewData["RefFormId"] = new SelectList(_context.Referrals, "FormId", "FormId", htmoneys.RefFormId);
            return View(htmoneys);
        }

        // GET: Htmoneys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var htmoneys = await _context.Htmoneys.SingleOrDefaultAsync(m => m.FormId == id);
            if (htmoneys == null)
            {
                return NotFound();
            }
            ViewData["FormId"] = new SelectList(_context.Forms, "FormId", "FormId", htmoneys.FormId);
            ViewData["RefFormId"] = new SelectList(_context.Referrals, "FormId", "FormId", htmoneys.RefFormId);
            return View(htmoneys);
        }

        // POST: Htmoneys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FormId,RefFormId,Income")] Htmoneys htmoneys)
        {
            if (id != htmoneys.FormId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(htmoneys);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HtmoneysExists(htmoneys.FormId))
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
            ViewData["FormId"] = new SelectList(_context.Forms, "FormId", "FormId", htmoneys.FormId);
            ViewData["RefFormId"] = new SelectList(_context.Referrals, "FormId", "FormId", htmoneys.RefFormId);
            return View(htmoneys);
        }

        // GET: Htmoneys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var htmoneys = await _context.Htmoneys
                .Include(h => h.Form)
                .Include(h => h.RefForm)
                .SingleOrDefaultAsync(m => m.FormId == id);
            if (htmoneys == null)
            {
                return NotFound();
            }

            return View(htmoneys);
        }

        // POST: Htmoneys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var htmoneys = await _context.Htmoneys.SingleOrDefaultAsync(m => m.FormId == id);
            _context.Htmoneys.Remove(htmoneys);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HtmoneysExists(int id)
        {
            return _context.Htmoneys.Any(e => e.FormId == id);
        }
    }
}
