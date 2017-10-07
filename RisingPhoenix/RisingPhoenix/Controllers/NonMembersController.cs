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
    public class NonMembersController : Controller
    {
        private readonly RisingPhoenixDBContext _context;

        public NonMembersController(RisingPhoenixDBContext context)
        {
            _context = context;
        }

        // GET: NonMembers
        public async Task<IActionResult> Index()
        {
            return View(await _context.NonMembers.ToListAsync());
        }

        // GET: NonMembers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nonMembers = await _context.NonMembers
                .SingleOrDefaultAsync(m => m.NonMemId == id);
            if (nonMembers == null)
            {
                return NotFound();
            }

            return View(nonMembers);
        }

        // GET: NonMembers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NonMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NonMemId,NonMemType,NonMemName,NonMemPhone,NonMemEmail")] NonMembers nonMembers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nonMembers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nonMembers);
        }

        // GET: NonMembers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nonMembers = await _context.NonMembers.SingleOrDefaultAsync(m => m.NonMemId == id);
            if (nonMembers == null)
            {
                return NotFound();
            }
            return View(nonMembers);
        }

        // POST: NonMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NonMemId,NonMemType,NonMemName,NonMemPhone,NonMemEmail")] NonMembers nonMembers)
        {
            if (id != nonMembers.NonMemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nonMembers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NonMembersExists(nonMembers.NonMemId))
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
            return View(nonMembers);
        }

        // GET: NonMembers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nonMembers = await _context.NonMembers
                .SingleOrDefaultAsync(m => m.NonMemId == id);
            if (nonMembers == null)
            {
                return NotFound();
            }

            return View(nonMembers);
        }

        // POST: NonMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nonMembers = await _context.NonMembers.SingleOrDefaultAsync(m => m.NonMemId == id);
            _context.NonMembers.Remove(nonMembers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NonMembersExists(int id)
        {
            return _context.NonMembers.Any(e => e.NonMemId == id);
        }
    }
}
