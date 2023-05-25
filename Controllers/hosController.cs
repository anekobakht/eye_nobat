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
    public class hosController : Controller
    {
        private readonly eye_nobatContext _context;

        public hosController(eye_nobatContext context)
        {
            _context = context;
        }

        // GET: hos
        public async Task<IActionResult> Index()
        {
            
            var eye_nobatContext = _context.hos.AsNoTracking().Include(h => h.uni);
            if (HttpContext.Session.GetString("rule") == "admin")
            {
                ViewData["uni_id"] = new SelectList(_context.uni, "id", "name");
                eye_nobatContext = _context.hos.AsNoTracking().Include(h => h.uni);
            }
            else if (HttpContext.Session.GetString("rule") == "uni")
            {
                ViewData["uni_id"] = new SelectList(_context.uni.Where(s => s.id == long.Parse(HttpContext.Session.GetString("id"))), "id", "name");
                eye_nobatContext = _context.hos.AsNoTracking().Where(h => h.uni_id == long.Parse(HttpContext.Session.GetString("id"))).Include(h => h.uni);
            }
            return View(await eye_nobatContext.ToListAsync());
        }

        // GET: hos/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.hos == null)
            {
                return NotFound();
            }

            var hos = await _context.hos
                .Include(h => h.uni)
                .FirstOrDefaultAsync(m => m.id == id);
            if (hos == null)
            {
                return NotFound();
            }

            return View(hos);
        }

        // GET: hos/Create
        public IActionResult Create()
        {
            ViewData["uni_id"] = new SelectList(_context.uni.Where(s=>s.id== long.Parse(HttpContext.Session.GetString("id"))), "id", "name");
            return View();
        }

        // POST: hos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,phone,address,flname,uname,upass,uni_id")] hos hos)
        {
                _context.Add(hos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }

        // GET: hos/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.hos == null)
            {
                return NotFound();
            }

            var hos = await _context.hos.FindAsync(id);
            if (hos == null)
            {
                return NotFound();
            }
            ViewData["uni_id"] = new SelectList(_context.uni, "id", "name", hos.uni_id);
            return View(hos);
        }

        // POST: hos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("id,name,phone,address,flname,uname,upass,uni_id")] hos hos)
        {
            if (id != hos.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!hosExists(hos.id))
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
            ViewData["uni_id"] = new SelectList(_context.uni, "id", "name", hos.uni_id);
            return View(hos);
        }

        // GET: hos/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.hos == null)
            {
                return NotFound();
            }

            var hos = await _context.hos
                .Include(h => h.uni)
                .FirstOrDefaultAsync(m => m.id == id);
            if (hos == null)
            {
                return NotFound();
            }

            return View(hos);
        }

        // POST: hos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.hos == null)
            {
                return Problem("Entity set 'eye_nobatContext.hos'  is null.");
            }
            var hos = await _context.hos.FindAsync(id);
            if (hos != null)
            {
                _context.hos.Remove(hos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool hosExists(long id)
        {
          return (_context.hos?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
