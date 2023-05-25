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
    public class bakhshesController : Controller
    {
        private readonly eye_nobatContext _context;

        public bakhshesController(eye_nobatContext context)
        {
            _context = context;
        }

        // GET: bakhshes
        public async Task<IActionResult> Index()
        {

            var eye_nobatContext = _context.v_uni_hos_bakhsh1.AsNoTracking();
            if (HttpContext.Session.GetString("rule") == "admin")
            {
                ViewData["hos_id"] = new SelectList(_context.v_uni_hos1, "hos_id", "hos_name");
                eye_nobatContext = _context.v_uni_hos_bakhsh1.AsNoTracking();
            }
            else if (HttpContext.Session.GetString("rule") == "uni")
            {
                ViewData["hos_id"] = new SelectList(_context.v_uni_hos1.Where(s => s.uni_id == long.Parse(HttpContext.Session.GetString("id"))), "hos_id", "hos_name");
                eye_nobatContext =_context.v_uni_hos_bakhsh1.AsNoTracking().Where(s => s.uni_id == long.Parse(HttpContext.Session.GetString("id")));
            }
            else if (HttpContext.Session.GetString("rule") == "hos")
            {
                ViewData["hos_id"] = new SelectList(_context.v_uni_hos1.Where(s => s.hos_id == long.Parse(HttpContext.Session.GetString("id"))), "hos_id", "hos_name");
                eye_nobatContext = _context.v_uni_hos_bakhsh1.AsNoTracking().Where(s => s.hos_id == long.Parse(HttpContext.Session.GetString("id")));
            }
            return View(await eye_nobatContext.ToListAsync());
        }

        // GET: bakhshes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.bakhsh == null)
            {
                return NotFound();
            }

            var bakhsh = await _context.bakhsh
                .Include(b => b.hos)
                .FirstOrDefaultAsync(m => m.id == id);
            if (bakhsh == null)
            {
                return NotFound();
            }

            return View(bakhsh);
        }

        // GET: bakhshes/Create
        public IActionResult Create()
        {
            ViewData["hos_id"] = new SelectList(_context.v_uni_hos1.Where(s=>s.uni_id== long.Parse(HttpContext.Session.GetString("id"))), "hos_id", "hos_name");
            return View();
        }

        // POST: bakhshes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,phone,address,flname,uname,upass,hos_id")] bakhsh bakhsh)
        {
            
                _context.Add(bakhsh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
           
        }

        // GET: bakhshes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.bakhsh == null)
            {
                return NotFound();
            }

            var bakhsh = await _context.bakhsh.FindAsync(id);
            if (bakhsh == null)
            {
                return NotFound();
            }
            ViewData["hos_id"] = new SelectList(_context.hos, "id", "name", bakhsh.hos_id);
            return View(bakhsh);
        }

        // POST: bakhshes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("id,name,phone,address,flname,uname,upass,hos_id")] bakhsh bakhsh)
        {
            if (id != bakhsh.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bakhsh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!bakhshExists(bakhsh.id))
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
            ViewData["hos_id"] = new SelectList(_context.hos, "id", "name", bakhsh.hos_id);
            return View(bakhsh);
        }

        // GET: bakhshes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.bakhsh == null)
            {
                return NotFound();
            }

            var bakhsh = await _context.bakhsh
                .Include(b => b.hos)
                .FirstOrDefaultAsync(m => m.id == id);
            if (bakhsh == null)
            {
                return NotFound();
            }

            return View(bakhsh);
        }

        // POST: bakhshes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.bakhsh == null)
            {
                return Problem("Entity set 'eye_nobatContext.bakhsh'  is null.");
            }
            var bakhsh = await _context.bakhsh.FindAsync(id);
            if (bakhsh != null)
            {
                _context.bakhsh.Remove(bakhsh);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool bakhshExists(long id)
        {
          return (_context.bakhsh?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
