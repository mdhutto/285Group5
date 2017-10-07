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
    public class Face2FacesController : Controller
    {
        private readonly RisingPhoenixDBContext _context;

        public Face2FacesController(RisingPhoenixDBContext context)
        {
            _context = context;
        }

        // GET: Face2Faces
        public async Task<IActionResult> Index()
        {
            var risingPhoenixDBContext = _context.Face2Faces.Include(f => f.Form).Include(f => f.MetId1Navigation).Include(f => f.MetId2Navigation).Include(f => f.MetId3Navigation).Include(f => f.MetId4Navigation);
            return View(await risingPhoenixDBContext.ToListAsync());
        }

        // GET: Face2Faces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var face2Faces = await _context.Face2Faces
                .Include(f => f.Form)
                .Include(f => f.MetId1Navigation)
                .Include(f => f.MetId2Navigation)
                .Include(f => f.MetId3Navigation)
                .Include(f => f.MetId4Navigation)
                .SingleOrDefaultAsync(m => m.FormId == id);
            if (face2Faces == null)
            {
                return NotFound();
            }

            return View(face2Faces);
        }

        // GET: Face2Faces/Create
        public IActionResult Create()
        {
            ViewData["FormId"] = new SelectList(_context.Forms, "FormId", "FormId");
            ViewData["MetId1"] = new SelectList(_context.Members, "MemberId", "Company");
            ViewData["MetId2"] = new SelectList(_context.Members, "MemberId", "Company");
            ViewData["MetId3"] = new SelectList(_context.Members, "MemberId", "Company");
            ViewData["MetId4"] = new SelectList(_context.Members, "MemberId", "Company");
            return View();
        }

        // POST: Face2Faces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FormId,Location,MetId1,MetId2,MetId3,MetId4")] Face2Faces face2Faces)
        {
            if (ModelState.IsValid)
            {
                _context.Add(face2Faces);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FormId"] = new SelectList(_context.Forms, "FormId", "FormId", face2Faces.FormId);
            ViewData["MetId1"] = new SelectList(_context.Members, "MemberId", "Company", face2Faces.MetId1);
            ViewData["MetId2"] = new SelectList(_context.Members, "MemberId", "Company", face2Faces.MetId2);
            ViewData["MetId3"] = new SelectList(_context.Members, "MemberId", "Company", face2Faces.MetId3);
            ViewData["MetId4"] = new SelectList(_context.Members, "MemberId", "Company", face2Faces.MetId4);
            return View(face2Faces);
        }

        // GET: Face2Faces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var face2Faces = await _context.Face2Faces.SingleOrDefaultAsync(m => m.FormId == id);
            if (face2Faces == null)
            {
                return NotFound();
            }
            ViewData["FormId"] = new SelectList(_context.Forms, "FormId", "FormId", face2Faces.FormId);
            ViewData["MetId1"] = new SelectList(_context.Members, "MemberId", "Company", face2Faces.MetId1);
            ViewData["MetId2"] = new SelectList(_context.Members, "MemberId", "Company", face2Faces.MetId2);
            ViewData["MetId3"] = new SelectList(_context.Members, "MemberId", "Company", face2Faces.MetId3);
            ViewData["MetId4"] = new SelectList(_context.Members, "MemberId", "Company", face2Faces.MetId4);
            return View(face2Faces);
        }

        // POST: Face2Faces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FormId,Location,MetId1,MetId2,MetId3,MetId4")] Face2Faces face2Faces)
        {
            if (id != face2Faces.FormId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(face2Faces);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Face2FacesExists(face2Faces.FormId))
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
            ViewData["FormId"] = new SelectList(_context.Forms, "FormId", "FormId", face2Faces.FormId);
            ViewData["MetId1"] = new SelectList(_context.Members, "MemberId", "Company", face2Faces.MetId1);
            ViewData["MetId2"] = new SelectList(_context.Members, "MemberId", "Company", face2Faces.MetId2);
            ViewData["MetId3"] = new SelectList(_context.Members, "MemberId", "Company", face2Faces.MetId3);
            ViewData["MetId4"] = new SelectList(_context.Members, "MemberId", "Company", face2Faces.MetId4);
            return View(face2Faces);
        }

        // GET: Face2Faces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var face2Faces = await _context.Face2Faces
                .Include(f => f.Form)
                .Include(f => f.MetId1Navigation)
                .Include(f => f.MetId2Navigation)
                .Include(f => f.MetId3Navigation)
                .Include(f => f.MetId4Navigation)
                .SingleOrDefaultAsync(m => m.FormId == id);
            if (face2Faces == null)
            {
                return NotFound();
            }

            return View(face2Faces);
        }

        // POST: Face2Faces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var face2Faces = await _context.Face2Faces.SingleOrDefaultAsync(m => m.FormId == id);
            _context.Face2Faces.Remove(face2Faces);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Face2FacesExists(int id)
        {
            return _context.Face2Faces.Any(e => e.FormId == id);
        }
    }
}
