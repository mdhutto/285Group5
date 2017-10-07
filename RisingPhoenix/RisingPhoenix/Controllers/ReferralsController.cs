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
    public class ReferralsController : Controller
    {
        private readonly RisingPhoenixDBContext _context;

        public ReferralsController(RisingPhoenixDBContext context)
        {
            _context = context;
        }

        // GET: Referrals
        public async Task<IActionResult> Index()
        {
            var risingPhoenixDBContext = _context.Referrals.Include(r => r.Client).Include(r => r.Recipient).Include(r => r.Sender);
            return View(await risingPhoenixDBContext.ToListAsync());
        }

        // GET: Referrals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var referrals = await _context.Referrals
                .Include(r => r.Client)
                .Include(r => r.Recipient)
                .Include(r => r.Sender)
                .SingleOrDefaultAsync(m => m.FormId == id);
            if (referrals == null)
            {
                return NotFound();
            }

            return View(referrals);
        }

        // GET: Referrals/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientName");
            ViewData["RecipientId"] = new SelectList(_context.Members, "MemberId", "Company");
            ViewData["SenderId"] = new SelectList(_context.Members, "MemberId", "Company");
            return View();
        }

        // POST: Referrals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FormId,SenderId,RecipientId,ClientId,SenderMsg")] Referrals referrals)
        {
            if (ModelState.IsValid)
            {
                _context.Add(referrals);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientName", referrals.ClientId);
            ViewData["RecipientId"] = new SelectList(_context.Members, "MemberId", "Company", referrals.RecipientId);
            ViewData["SenderId"] = new SelectList(_context.Members, "MemberId", "Company", referrals.SenderId);
            return View(referrals);
        }

        // GET: Referrals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var referrals = await _context.Referrals.SingleOrDefaultAsync(m => m.FormId == id);
            if (referrals == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientName", referrals.ClientId);
            ViewData["RecipientId"] = new SelectList(_context.Members, "MemberId", "Company", referrals.RecipientId);
            ViewData["SenderId"] = new SelectList(_context.Members, "MemberId", "Company", referrals.SenderId);
            return View(referrals);
        }

        // POST: Referrals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FormId,SenderId,RecipientId,ClientId,SenderMsg")] Referrals referrals)
        {
            if (id != referrals.FormId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(referrals);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReferralsExists(referrals.FormId))
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
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "ClientName", referrals.ClientId);
            ViewData["RecipientId"] = new SelectList(_context.Members, "MemberId", "Company", referrals.RecipientId);
            ViewData["SenderId"] = new SelectList(_context.Members, "MemberId", "Company", referrals.SenderId);
            return View(referrals);
        }

        // GET: Referrals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var referrals = await _context.Referrals
                .Include(r => r.Client)
                .Include(r => r.Recipient)
                .Include(r => r.Sender)
                .SingleOrDefaultAsync(m => m.FormId == id);
            if (referrals == null)
            {
                return NotFound();
            }

            return View(referrals);
        }

        // POST: Referrals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var referrals = await _context.Referrals.SingleOrDefaultAsync(m => m.FormId == id);
            _context.Referrals.Remove(referrals);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReferralsExists(int id)
        {
            return _context.Referrals.Any(e => e.FormId == id);
        }
    }
}
