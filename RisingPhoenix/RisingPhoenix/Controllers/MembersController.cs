using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RisingPhoenix.Models;

namespace RisingPhoenix.Controllers
{
    public class MembersController : Controller
    {
        private readonly TRPDbContext _context;

        public MembersController(TRPDbContext context)
        {
            _context = context;
        }

        // GET: Members
        public async Task<IActionResult> Index()
        {
            return View(await _context.Members.ToListAsync());
        }

        // GET: Members/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var members = await _context.Members
                .SingleOrDefaultAsync(m => m.MemberId == id);
            if (members == null)
            {
                return NotFound();
            }

            return View(members);
        }

        // GET: Members/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind(
                "MemberId,FirstName,LastName,Company,Profession,Phone,Email,Website,MemberSince,AbsenceCount,AdminBool,frec,fsent,fincome,ff2f")]
            Members members)
        {
            members.frec = 0;
            members.fsent = 0;
            members.fincome = 0;
            members.ff2f = 0;

            members.AbsenceCount = 0;
            members.Password = "password";
            if (ModelState.IsValid)
            {
                _context.Add(members);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(members);
        }

        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var members = await _context.Members.SingleOrDefaultAsync(m => m.MemberId == id);
            if (members == null)
            {
                return NotFound();
            }
            return View(members);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind(
                "MemberId,FirstName,LastName,Company,Profession,Phone,Email,Website,MemberSince,AbsenceCount,AdminBool,frec,fsent,fincome,ff2f")]
            Members members)
        {
            members.Password = "password";
            if (id != members.MemberId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(members);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembersExists(members.MemberId))
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
            return View(members);
        }

        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var members = await _context.Members
                .SingleOrDefaultAsync(m => m.MemberId == id);
            if (members == null)
            {
                return NotFound();
            }

            return View(members);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var members = await _context.Members.SingleOrDefaultAsync(m => m.MemberId == id);
            _context.Members.Remove(members);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembersExists(int id)
        {
            return _context.Members.Any(e => e.MemberId == id);
        }





        public async Task<IActionResult> Stats()
        {
            return View(await _context.Members.ToListAsync());
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Members inputModel)
        {
            if (!IsAuthentic(inputModel.Username, inputModel.Password))
                return View();

// create claims
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "Allie"),
                new Claim(ClaimTypes.Email, inputModel.Username)
            };

// create identity
            ClaimsIdentity identity = new ClaimsIdentity(claims, "cookie");

// create principal
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

// sign-in
            await HttpContext.SignInAsync(

                principal: principal);

            return RedirectToAction("Index", "Home");
        }

        private bool IsAuthentic(string username, string password)
        {
            

            //fix this 

            return true;
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();


            return RedirectToAction("Login");
        }
    }
}
