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
    public class adminsController : Controller
    {
        JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
        private readonly eye_nobatContext _context;

        public adminsController(eye_nobatContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> dashboard()
        {
            var q1 =await _context.v_count_never.AsNoTracking().FirstOrDefaultAsync();
            ViewBag.v_count_never = q1.count;

            var q2 = await _context.v_count_uni.AsNoTracking().FirstOrDefaultAsync();
            ViewBag.v_count_uni = q2.count;

            var q3 = await _context.v_count_hos.AsNoTracking().FirstOrDefaultAsync();
            ViewBag.v_count_hos = q3.count;

            var q4 = await _context.v_count_bakhsh.AsNoTracking().FirstOrDefaultAsync();
            ViewBag.v_count_bakhsh = q4.count;
            if (HttpContext.Session.GetString("rule") == "admin")
            {
                ViewBag.DataPoints = JsonConvert.SerializeObject(_context.v_nemudar_never_uni, _jsonSetting);
            }
            else if (HttpContext.Session.GetString("rule") == "uni")
            {
                ViewBag.DataPoints = JsonConvert.SerializeObject(_context.v_nemudar_never_hos.Where(s=>s.uni_id== long.Parse(HttpContext.Session.GetString("id"))), _jsonSetting);
            }
            else if (HttpContext.Session.GetString("rule") == "hos")
            {
                ViewBag.DataPoints = JsonConvert.SerializeObject(_context.v_nemudar_never_bakhsh.Where(s=>s.hos_id== long.Parse(HttpContext.Session.GetString("id"))), _jsonSetting);
            }
           
            return View();
        }
        public async Task<IActionResult> change_pass()
        {
            if (HttpContext.Session.GetString("rule") == "admin")
            {
                var q1 = _context.admin.AsNoTracking().Where(s => s.id == long.Parse(HttpContext.Session.GetString("id"))).FirstOrDefault();
                ViewBag.flname = q1.flname;
                ViewBag.uname = q1.uname;
                ViewBag.pass = q1.pass;
            }
            else if (HttpContext.Session.GetString("rule") == "uni")
            {
                var q1 = _context.uni.AsNoTracking().Where(s => s.id == long.Parse(HttpContext.Session.GetString("id"))).FirstOrDefault();
                ViewBag.flname = q1.flname;
                ViewBag.uname = q1.uname;
                ViewBag.pass = q1.upass;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> change_pass(string flname,string uname,string pass)
        {
            if (HttpContext.Session.GetString("rule") == "admin")
            {
                admin admin = new admin();
                admin.id = long.Parse(HttpContext.Session.GetString("id"));
                admin.pass = pass;
                admin.flname = flname;
                admin.uname = uname;
                _context.Update(admin);
                await _context.SaveChangesAsync();
                TempData["payam"] = "change_pass";
               return RedirectToAction("main", "admins");
            }
           else if (HttpContext.Session.GetString("rule") == "uni")
            {
                var q1 = _context.uni.AsNoTracking().Where(s => s.id == long.Parse(HttpContext.Session.GetString("id"))).FirstOrDefault();
                q1.upass = pass;
                _context.Update(q1);
                await _context.SaveChangesAsync();
                TempData["payam"] = "change_pass";
                return RedirectToAction("main", "admins");
            }
            return  RedirectToAction("main", "admins");
        }
        public async Task<IActionResult> main()
        {
           ViewBag.flname= HttpContext.Session.GetString("flname");
           ViewBag.rule= HttpContext.Session.GetString("rule");
            return View();
        }
        public async Task<IActionResult> login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> login(string uname, string pass)
        {

            var q1 = _context.bakhsh.AsNoTracking().Where(s => s.uname == uname).Where(s => s.upass == pass).FirstOrDefault();
            if (q1 != null)
            {
                HttpContext.Session.SetString("rule", "bakhsh");
                HttpContext.Session.SetString("flname", q1.flname.ToString());
                HttpContext.Session.SetString("id", q1.id.ToString());
                return RedirectToAction("Index","nevers");
            }
            else
            {
                var q2 = _context.hos.AsNoTracking().Where(s => s.uname == uname).Where(s => s.upass == pass).FirstOrDefault();
                if (q2 != null)
                {
                    HttpContext.Session.SetString("rule", "hos");
                    HttpContext.Session.SetString("flname", q2.flname.ToString());
                    HttpContext.Session.SetString("id", q2.id.ToString());
                    return RedirectToAction("dashboard","admins");
                }
                else
                {
                    var q3 = _context.uni.AsNoTracking().Where(s => s.uname == uname).Where(s => s.upass == pass).FirstOrDefault();
                    if (q3 != null)
                    {
                        HttpContext.Session.SetString("rule", "uni");
                        HttpContext.Session.SetString("flname", q3.flname.ToString());
                        HttpContext.Session.SetString("id", q3.id.ToString());
                        return RedirectToAction("dashboard", "admins");
                    }
                    else
                    {
                        var q4 = await _context.admin.AsNoTracking().Where(s => s.uname == uname).Where(s => s.pass == pass).ToListAsync();
                        if (q4.Count != 0)
                        {
                            HttpContext.Session.SetString("rule", "admin");
                            HttpContext.Session.SetString("flname", q4.FirstOrDefault().flname.ToString());
                            HttpContext.Session.SetString("id", q4.FirstOrDefault().id.ToString());
                            return RedirectToAction("dashboard", "admins");
                        }
                        else
                        {
                            ViewBag.payam = "auth";
                            return RedirectToAction("login");
                        }
                    }
                }
            }

        }

        // GET: admins
        public async Task<IActionResult> Index()
        {
              return _context.admin != null ? 
                          View(await _context.admin.ToListAsync()) :
                          Problem("Entity set 'eye_nobatContext.admin'  is null.");
        }

        // GET: admins/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.admin == null)
            {
                return NotFound();
            }

            var admin = await _context.admin
                .FirstOrDefaultAsync(m => m.id == id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // GET: admins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: admins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string flname, string uname, string pass, admin admin)
        {
            admin.flname = flname;
            admin.uname = uname;
            admin.pass = pass;
            _context.Add(admin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: admins/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.admin == null)
            {
                return NotFound();
            }

            var admin = await _context.admin.FindAsync(id);
            ViewBag.pass_val = admin.pass.ToString();
            if (admin == null)
            {
                return NotFound();
            }
            return View(admin);
        }

        // POST: admins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("id,flname,uname,pass")] admin admin)
        {
            if (id != admin.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(admin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!adminExists(admin.id))
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
            return View(admin);
        }

        // GET: admins/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.admin == null)
            {
                return NotFound();
            }

            var admin = await _context.admin
                .FirstOrDefaultAsync(m => m.id == id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // POST: admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.admin == null)
            {
                return Problem("Entity set 'eye_nobatContext.admin'  is null.");
            }
            var admin = await _context.admin.FindAsync(id);
            if (admin != null)
            {
                _context.admin.Remove(admin);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool adminExists(long id)
        {
          return (_context.admin?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
