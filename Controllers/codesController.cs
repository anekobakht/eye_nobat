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
    public class codesController : Controller
    {
        private readonly eye_nobatContext _context;

        public codesController(eye_nobatContext context)
        {
            _context = context;
        }

        // GET: codes
        public async Task<IActionResult> Index()
        {
              return _context.code != null ? 
                          View(await _context.code.ToListAsync()) :
                          Problem("Entity set 'eye_nobatContext.code'  is null.");
        }

        // GET: codes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.code == null)
            {
                return NotFound();
            }

            var code = await _context.code
                .FirstOrDefaultAsync(m => m.id == id);
            if (code == null)
            {
                return NotFound();
            }

            return View(code);
        }

        // GET: codes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: codes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string name, long num, string sms, code code)
        {
            code.name = name;
            code.num = num;
            if(sms=="on")
            {
                code.sms = true;
            }
            else
            {
                code.sms = false;

            }

            _context.Add(code);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: codes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.code == null)
            {
                return NotFound();
            }

            var code = await _context.code.FindAsync(id);
            if (code == null)
            {
                return NotFound();
            }
            return View(code);
        }

        // POST: codes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id,string sms, [Bind("id,name,num,sms")] code code)
        {
            if (id != code.id)
            {
                return NotFound();
            }

           
                try
                {
                if (sms == "on")
                {
                    code.sms = true;
                }
                else
                {
                    code.sms = false;

                }
                    _context.Update(code);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!codeExists(code.id))
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

        // GET: codes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.code == null)
            {
                return NotFound();
            }

            var code = await _context.code
                .FirstOrDefaultAsync(m => m.id == id);
            if (code == null)
            {
                return NotFound();
            }

            return View(code);
        }

        // POST: codes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.code == null)
            {
                return Problem("Entity set 'eye_nobatContext.code'  is null.");
            }
            var code = await _context.code.FindAsync(id);
            if (code != null)
            {
                _context.code.Remove(code);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool codeExists(long id)
        {
          return (_context.code?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
