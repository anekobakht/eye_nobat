using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eye_nobat.Data;
using eye_nobat.Models;
using Newtonsoft.Json;

namespace eye_nobat.Controllers
{
    public class kolisController : Controller
    {
        private readonly eye_nobatContext _context;
        JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
        public kolisController(eye_nobatContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> login(string uname, string pass)
        {
            if((uname=="admin")&(pass=="1qaz!QAZ"))
            {
                return RedirectToAction("check", "kolis");
            }
            else
            {
                ViewBag.payam = "auth";
                return RedirectToAction("login");
            }
           

        }

        public async Task<IActionResult> nemudar_count_hos(long uni_id)
        {
           
                ViewBag.DataPoints = JsonConvert.SerializeObject(_context.v_count_hos, _jsonSetting);
                return View();
           


        }


        // GET: kolis
        public async Task<IActionResult> Index()
        {
              return _context.koli != null ? 
                          View(await _context.koli.ToListAsync()) :
                          Problem("Entity set 'eye_nobatContext.koli'  is null.");
        }

        public async Task<IActionResult> check()
        {
            return _context.koli != null ?
                        View(await _context.koli.Where(s => (s.etmam == false)||(s.etmam==null)).ToListAsync()):
                        Problem("Entity set 'eye_nobatContext.koli'  is null.");
        }

        // GET: kolis/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.koli == null)
            {
                return NotFound();
            }

            var koli = await _context.koli
                .FirstOrDefaultAsync(m => m.id == id);
            if (koli == null)
            {
                return NotFound();
            }

            return View(koli);
        }

        // GET: kolis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: kolis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(long id,string flname,string moshahede , string ejra,string etmam,string name_hos,string date_vorud,string saat_vorud,koli koli)
        {
            koli.id = id;
            koli.flname = flname;
            koli.name_hos = name_hos;
            koli.date_vorud = date_vorud;
            koli.saat_vorud = saat_vorud;
            if(moshahede =="on")
            {
                koli.moshahede = true;
            }
            if (moshahede != "on")
            {
                koli.moshahede = false;
            }
            if (ejra == "on")
            {
                koli.ejra = true;
            }
            if (ejra != "on")
            {
                koli.ejra = false;
            }
            if (etmam == "on")
            {
                koli.etmam = true;
            }
            if (etmam != "on")
            {
                koli.etmam = false;
            }
            _context.Add(koli);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
           
        }

        // GET: kolis/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.koli == null)
            {
                return NotFound();
            }

            var koli = await _context.koli.FindAsync(id);
            if (koli == null)
            {
                return NotFound();
            }
            return View(koli);
        }

        // POST: kolis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id,string moshahede,string ejra,string etmam,  [Bind("id,flname,moshahede,ejra,etmam,name_hos,date_vorud,saat_vorud")] koli koli)
        {
            if (id != koli.id)
            {
                return NotFound();
            }

                try
                {
                if(moshahede=="on")
                {
                    koli.moshahede= true;
                }
                else if(moshahede=="off")
                {
                    koli.moshahede = false;
                }

                if (ejra == "on")
                {
                    koli.ejra = true;
                }
                else if (ejra == "off")
                {
                    koli.ejra = false;
                }

                if (etmam == "on")
                {
                    koli.etmam = true;
                }
                else if (etmam == "off")
                {
                    koli.etmam = false;
                }
                _context.Update(koli);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!koliExists(koli.id))
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

        // GET: kolis/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.koli == null)
            {
                return NotFound();
            }

            var koli = await _context.koli
                .FirstOrDefaultAsync(m => m.id == id);
            if (koli == null)
            {
                return NotFound();
            }

            return View(koli);
        }

        // POST: kolis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.koli == null)
            {
                return Problem("Entity set 'eye_nobatContext.koli'  is null.");
            }
            var koli = await _context.koli.FindAsync(id);
            if (koli != null)
            {
                _context.koli.Remove(koli);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool koliExists(long id)
        {
          return (_context.koli?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
