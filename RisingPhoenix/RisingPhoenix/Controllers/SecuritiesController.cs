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
    public class SecuritiesController : Controller
    {
        private readonly TRPDbContext _context;

        public SecuritiesController(TRPDbContext context)
        {
            _context = context;
        }

        // GET: Securities
        public async Task<IActionResult> Index()
        {
            var TRPDbContext = _context.Security.Include(s => s.Member);
            return View(await TRPDbContext.ToListAsync());
        }

        // GET: Securities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var security = await _context.Security
                .Include(s => s.Member)
                .SingleOrDefaultAsync(m => m.MemberId == id);
            if (security == null)
            {
                return NotFound();
            }

            return View(security);
        }

        // GET: Securities/Create
        public IActionResult Create()
        {
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "Company");
            return View();
        }

        // POST: Securities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MemberId,Username,UserPass,ActiveBool")] Security security)
        {
            if (ModelState.IsValid)
            {
                _context.Add(security);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "Company", security.MemberId);
            return View(security);
        }

        // GET: Securities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var security = await _context.Security.SingleOrDefaultAsync(m => m.MemberId == id);
            if (security == null)
            {
                return NotFound();
            }
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "Company", security.MemberId);
            return View(security);
        }

        // POST: Securities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MemberId,Username,UserPass,ActiveBool")] Security security)
        {
            if (id != security.MemberId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(security);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SecurityExists(security.MemberId))
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
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "Company", security.MemberId);
            return View(security);
        }

        // GET: Securities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var security = await _context.Security
                .Include(s => s.Member)
                .SingleOrDefaultAsync(m => m.MemberId == id);
            if (security == null)
            {
                return NotFound();
            }

            return View(security);
        }

        // POST: Securities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var security = await _context.Security.SingleOrDefaultAsync(m => m.MemberId == id);
            _context.Security.Remove(security);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SecurityExists(int id)
        {
            return _context.Security.Any(e => e.MemberId == id);
        }
    }
}
