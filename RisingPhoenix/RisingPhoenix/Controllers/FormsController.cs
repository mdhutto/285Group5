using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RisingPhoenix.Models;
using MimeKit;
using MailKit.Net.Smtp;

namespace RisingPhoenix.Controllers
{
    public class FormsController : Controller
    {
        private readonly TRPDbContext _context;

        public FormsController(TRPDbContext context)
        {
            _context = context;
        }

        // GET: Forms
        public async Task<IActionResult> Index()
        {
            var TRPDbContext = _context.Forms.Include(r => r.Recipient).Include(r => r.Sender);
            return View(TRPDbContext);
        }

        // GET: Forms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forms = await _context.Forms
                .Include(r => r.Recipient)
                .Include(r => r.Sender)
                .SingleOrDefaultAsync(m => m.FormId == id);
            if (forms == null)
            {
                return NotFound();
            }

            return View(forms);
        }

    // GET: Forms/Create
    public IActionResult Create()
        {
            ViewData["RecipientId"] = new SelectList(_context.Members, "MemberId", "LastName");
            ViewData["SenderId"] = new SelectList(_context.Members, "MemberId", "LastName");
            return View();
        }

        // POST: Forms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FormId,FormType,FormDate,SenderId,RecipientId,Location,ClientName,ClientInfo,Income,NonMemberInfo")] Forms forms)
        {
            if (ModelState.IsValid)
            {
                _context.Add(forms);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RecipientId"] = new SelectList(_context.Members, "MemberId", "LastName", forms.RecipientId);
            ViewData["SenderId"] = new SelectList(_context.Members, "MemberId", "LastName", forms.SenderId);
            return View(forms);
        }

        // GET: Forms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forms = await _context.Forms.SingleOrDefaultAsync(m => m.FormId == id);
            if (forms == null)
            {
                return NotFound();
            }
            ViewData["RecipientId"] = new SelectList(_context.Members, "MemberId", "LastName", forms.RecipientId);
            ViewData["SenderId"] = new SelectList(_context.Members, "MemberId", "LastName", forms.SenderId);
            return View(forms);
        }

        // POST: Forms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FormId,FormType,FormDate,SenderId,RecipientId,Location,ClientName,ClientInfo,Income,NonMemberInfo")] Forms forms)
        {
            if (id != forms.FormId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(forms);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormsExists(forms.FormId))
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
            ViewData["RecipientId"] = new SelectList(_context.Members, "MemberId", "LastName", forms.RecipientId);
            ViewData["SenderId"] = new SelectList(_context.Members, "MemberId", "LastName", forms.SenderId);
            return View(forms);
        }

        // GET: Forms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forms = await _context.Forms
                .Include(r => r.Recipient)
                .Include(r => r.Sender)
                .SingleOrDefaultAsync(m => m.FormId == id);
            if (forms == null)
            {
                return NotFound();
            }

            return View(forms);
        }

        // POST: Forms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var forms = await _context.Forms.SingleOrDefaultAsync(m => m.FormId == id);
            _context.Forms.Remove(forms);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormsExists(int id)
        {
            return _context.Forms.Any(e => e.FormId == id);
        }

        // These are the individual create commands for each of the 3 different forms **********************************************

        public IActionResult CreateRS()
        {
            ViewData["RecipientId"] = new SelectList(_context.Members, "MemberId", "LastName");
            ViewData["SenderId"] = new SelectList(_context.Members, "MemberId", "LastName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRS([Bind("FormId,FormType,FormDate,SenderId,RecipientId,Location,ClientName,ClientInfo,Income,NonMemberInfo")] Forms forms)
        {
            forms.FormType = 1;
            forms.FormDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(forms);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RecipientId"] = new SelectList(_context.Members, "MemberId", "LastName", forms.RecipientId);
            ViewData["SenderId"] = new SelectList(_context.Members, "MemberId", "LastName", forms.SenderId);

            forms.Sender.fsent += 1;
            forms.Recipient.frec += 1;

            // THIS IS FOR SENDING MAIL ********************************************************
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("The Rising Phoenix", "285group5@gmail.com"));
            message.To.Add(new MailboxAddress("Member", "happie4cats@gmail.com"));
            message.Subject = "New TRP Referral!";
            message.Body = new TextPart("plain")
            {
                Text = "You have recieved the following Referral from "// + forms.Sender.FirstName + " " + forms.Sender.LastName 
            };
            using (var recipient = new SmtpClient())
            {
                recipient.Connect("smtp.gmail.com",587,false);
                recipient.Authenticate("285group5@gmail.com", "risingphoenix285");
                recipient.Send(message);
                recipient.Disconnect(true);
            }
            // THIS IS FOR SENDING MAIL ********************************************************

            return View(forms);
        }
        public IActionResult CreateHTM()
        {
            ViewData["RecipientId"] = new SelectList(_context.Members, "MemberId", "LastName");
            ViewData["SenderId"] = new SelectList(_context.Members, "MemberId", "LastName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateHTM([Bind("FormId,FormType,FormDate,SenderId,RecipientId,Location,ClientName,ClientInfo,Income,NonMemberInfo")] Forms forms)
        {
            forms.FormType = 2;
            forms.FormDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(forms);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RecipientId"] = new SelectList(_context.Members, "MemberId", "LastName", forms.RecipientId);
            ViewData["SenderId"] = new SelectList(_context.Members, "MemberId", "LastName", forms.SenderId);

            forms.Recipient.fincome += forms.Income;

            return View(forms);
        }
        public IActionResult CreateF2F()
        {
            ViewData["RecipientId"] = new SelectList(_context.Members, "MemberId", "LastName");
            ViewData["SenderId"] = new SelectList(_context.Members, "MemberId", "LastName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateF2F([Bind("FormId,FormType,FormDate,SenderId,RecipientId,Location,ClientName,ClientInfo,Income,NonMemberInfo")] Forms forms)
        {
            
            forms.FormType = 3;
            forms.FormDate = DateTime.Now;
            

            if (ModelState.IsValid)
            {
                _context.Add(forms);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RecipientId"] = new SelectList(_context.Members, "MemberId", "LastName", forms.RecipientId);
            ViewData["SenderId"] = new SelectList(_context.Members, "MemberId", "LastName", forms.SenderId);

            forms.Sender.ff2f += 1;
            forms.Recipient.ff2f += 1;

            return View(forms);
        }
    }
}
