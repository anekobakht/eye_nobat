using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eye_nobat.Data;
using eye_nobat.Models;

namespace eye_nobat.Controllers
{
    public class unisController : Controller
    {
        private readonly eye_nobatContext _context;

        public unisController(eye_nobatContext context)
        {
            _context = context;
        }

        // GET: unis
        public async Task<IActionResult> Index()
        {
            return _context.uni != null ?
                        View(await _context.uni.ToListAsync()) :
                        Problem("Entity set 'eye_nobatContext.uni'  is null.");
        }

        // GET: unis/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.uni == null)
            {
                return NotFound();
            }

            var uni = await _context.uni
                .FirstOrDefaultAsync(m => m.id == id);
            if (uni == null)
            {
                return NotFound();
            }

            return View(uni);
        }

        // GET: unis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: unis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string name, string phone, string address, string flname, string uname, string upass, uni uni)
        {
            uni.name = name;
            uni.phone = phone;
            uni.address = address;
            uni.flname = flname;
            uni.uname = uname;
            uni.upass = upass;
            _context.Add(uni);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: unis/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.uni == null)
            {
                return NotFound();
            }

            var uni = await _context.uni.FindAsync(id);
            ViewBag.upass = uni.upass.ToString();
            if (uni == null)
            {
                return NotFound();
            }
            return View(uni);
        }

        // POST: unis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("id,name,phone,address,flname,uname,upass")] uni uni)
        {
            if (id != uni.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uni);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!uniExists(uni.id))
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
            return View(uni);
        }

        // GET: unis/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.uni == null)
            {
                return NotFound();
            }

            var uni = await _context.uni
                .FirstOrDefaultAsync(m => m.id == id);
            if (uni == null)
            {
                return NotFound();
            }

            return View(uni);
        }

        // POST: unis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.uni == null)
            {
                return Problem("Entity set 'eye_nobatContext.uni'  is null.");
            }
            var uni = await _context.uni.FindAsync(id);
            if (uni != null)
            {
                _context.uni.Remove(uni);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool uniExists(long id)
        {
            return (_context.uni?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
