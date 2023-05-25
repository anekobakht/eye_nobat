using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Vml;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eye_nobat.Data;
using eye_nobat.Models;

namespace eye_nobat.Controllers
{
    public class peyvastsController : Controller
    {
        private readonly eye_nobatContext _context;

        public peyvastsController(eye_nobatContext context)
        {
            _context = context;
        }

        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
        public async Task<IActionResult> download_file(int id)
        {
            
            var q = _context.peyvast.Where(s => s.id == id).FirstOrDefault();
            if(q == null)
            {
                TempData["peyvast"] = "no";
                return RedirectToAction("Index");
            }
            byte[] byteArr = q.val;
            string mimeType = "application/jpg";
            return new FileContentResult(byteArr, mimeType)
            {
                FileDownloadName = $" فایل  {q.name}." + q.kind
            };

        }
        
        //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

        // GET: peyvasts
        public async Task<IActionResult> Index(long id)
        {
            if (id != 0)
            {
                HttpContext.Session.SetString("never_id", id.ToString());
            }
            
            var eye_nobatContext = _context.peyvast.Where(s=>s.never_id==long.Parse(HttpContext.Session.GetString("never_id"))).Include(p => p.never);
            return View(await eye_nobatContext.ToListAsync());
        }

        public async Task<IActionResult> Index_search(long id)
        {
            if (id != 0)
            {
                HttpContext.Session.SetString("never_id", id.ToString());
            }

            var eye_nobatContext = _context.peyvast.Where(s => s.never_id == long.Parse(HttpContext.Session.GetString("never_id"))).Include(p => p.never);
            return View(await eye_nobatContext.ToListAsync());
        }

        // GET: peyvasts/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.peyvast == null)
            {
                return NotFound();
            }

            var peyvast = await _context.peyvast
                .Include(p => p.never)
                .FirstOrDefaultAsync(m => m.id == id);
            if (peyvast == null)
            {
                return NotFound();
            }

            return View(peyvast);
        }

        public async Task<IActionResult> Details_no_action(long? id)
        {
            if (id == null || _context.peyvast == null)
            {
                return NotFound();
            }

            var peyvast = await _context.peyvast
                .Include(p => p.never)
                .FirstOrDefaultAsync(m => m.id == id);
            if (peyvast == null)
            {
                return NotFound();
            }

            return View(peyvast);
        }

        // GET: peyvasts/Create
        public IActionResult Create()
        {
            ViewData["never_id"] = new SelectList(_context.never.Where(s=>s.id==long.Parse(HttpContext.Session.GetString("never_id"))), "id", "flname");
            return View();
        }

        // POST: peyvasts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile file,long id,string name,long never_id, peyvast peyvast)
        {
            if (file != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    // Upload the file if less than 2 MB
                    if (memoryStream.Length < 10097152)
                    {
                        peyvast.val = memoryStream.ToArray();
                        peyvast.kind = System.IO.Path.GetExtension(file.FileName);
                    }
                    else
                    {
                        ModelState.AddModelError("peyvast1_never", "فایل پیوست اول بزرگتر از 2 مگ میباشد");
                    }
                }
            }
            peyvast.never_id = long.Parse(HttpContext.Session.GetString("never_id"));
            peyvast.name = name;
            _context.Add(peyvast);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: peyvasts/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.peyvast == null)
            {
                return NotFound();
            }

            var peyvast = await _context.peyvast.FindAsync(id);
            if (peyvast == null)
            {
                return NotFound();
            }
            ViewBag.id=id;
            ViewData["never_id"] = new SelectList(_context.never, "id", "flname", peyvast.never_id);
            return View(peyvast);
        }

        // POST: peyvasts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, IFormFile file, [Bind("id,name,val,never_id")] peyvast peyvast)
        {
            if (file != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    // Upload the file if less than 2 MB
                    if (memoryStream.Length < 10097152)
                    {
                        peyvast.val = memoryStream.ToArray();
                        peyvast.kind = System.IO.Path.GetExtension(file.FileName);
                    }
                    else
                    {
                        ModelState.AddModelError("peyvast1_never", "فایل پیوست اول بزرگتر از 2 مگ میباشد");
                    }
                }
            }
            else
            {
                var q=_context.peyvast.AsNoTracking().Where(s=>s.id==id).FirstOrDefault();
                peyvast.val=q?.val;
                peyvast.kind=q?.kind;
            }
            if (id != peyvast.id)
            {
                return NotFound();
            }


            try
            {
                _context.Update(peyvast);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!peyvastExists(peyvast.id))
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

        // GET: peyvasts/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.peyvast == null)
            {
                return NotFound();
            }

            var peyvast = await _context.peyvast
                .Include(p => p.never)
                .FirstOrDefaultAsync(m => m.id == id);
            if (peyvast == null)
            {
                return NotFound();
            }

            ViewBag.id=peyvast.id;
            return View(peyvast);
        }

        // POST: peyvasts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.peyvast == null)
            {
                return Problem("Entity set 'eye_nobatContext.peyvast'  is null.");
            }
            var peyvast = await _context.peyvast.FindAsync(id);
            if (peyvast != null)
            {
                _context.peyvast.Remove(peyvast);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool peyvastExists(long id)
        {
          return (_context.peyvast?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
