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
using System.Collections.Generic;

namespace eye_nobat.Controllers
{
    public class neversController : Controller
    {
        JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
        private readonly eye_nobatContext _context;

        public neversController(eye_nobatContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> tedad_bakhsh()
        {
            if (HttpContext.Session.GetString("rule") == "admin")
            {
                return _context.v_tedad_bakhsh != null ?
                                      View(await _context.v_tedad_bakhsh.ToListAsync()) :
                                      Problem("Entity set 'v_tedad_bakhsh.code'  is null.");
            }
            else if (HttpContext.Session.GetString("rule") == "uni")
            {
                return _context.v_tedad_bakhsh != null ?
                                      View(await _context.v_tedad_bakhsh.Where(s => s.uni_id == long.Parse(HttpContext.Session.GetString("id"))).ToListAsync()) :
                                      Problem("Entity set 'v_tedad_bakhsh.code'  is null.");
            }

            else if (HttpContext.Session.GetString("rule") == "hos")
            {
                return _context.v_tedad_bakhsh != null ?
                                      View(await _context.v_tedad_bakhsh.Where(s => s.hos_id == long.Parse(HttpContext.Session.GetString("id"))).ToListAsync()) :
                                      Problem("Entity set 'v_tedad_bakhsh.code'  is null.");
            }
            else if (HttpContext.Session.GetString("rule") == "bakhsh")
            {
                return _context.v_tedad_bakhsh != null ?
                                      View(await _context.v_tedad_bakhsh.Where(s => s.bakhsh_id == long.Parse(HttpContext.Session.GetString("id"))).ToListAsync()) :
                                      Problem("Entity set 'v_tedad_bakhsh.code'  is null.");
            }

            else
            {
                return RedirectToAction("login", "admins");
            }

        }

        public async Task<IActionResult> tedad_jensiat()
        {
            return _context.v_nemudar_jensiat != null ?
                       View(await _context.v_nemudar_jensiat.ToListAsync()) :
                       Problem("Entity set 'eye_nobatContext.code'  is null.");
        }

        public async Task<IActionResult> nemudar_jensiat()
        {
            ViewBag.DataPoints = JsonConvert.SerializeObject(_context.v_nemudar_jensiat, _jsonSetting);
            return View();
        }

        public async Task<IActionResult> nemudar_never_uni()
        {
            ViewBag.DataPoints = JsonConvert.SerializeObject(_context.v_nemudar_never_uni, _jsonSetting);
            ViewBag.unis = new SelectList(_context.v_nemudar_never_uni, "id", "name");
            return View();
        }


        public async Task<IActionResult> nemudar_never_hos(long uni_id)
        {
            if (HttpContext.Session.GetString("rule") == "admin")
            {
                ViewBag.DataPoints = JsonConvert.SerializeObject(_context.v_nemudar_never_hos.Where(s => s.uni_id == uni_id), _jsonSetting);
                ViewBag.hos = new SelectList(_context.v_nemudar_never_hos.Where(s => s.uni_id == uni_id), "id", "name");
                return View();
            }
            else if (HttpContext.Session.GetString("rule") == "uni")
            {
                ViewBag.DataPoints = JsonConvert.SerializeObject(_context.v_nemudar_never_hos.Where(s => s.uni_id == long.Parse(HttpContext.Session.GetString("id"))), _jsonSetting);
                ViewBag.hos = new SelectList(_context.v_nemudar_never_hos.Where(s => s.uni_id == long.Parse(HttpContext.Session.GetString("id"))), "id", "name");
                return View();
            }
            else
            {
                return RedirectToAction("login", "admins");
            }


        }
        public async Task<IActionResult> nemudar_never_bakhsh(long hos_id)
        {
            ViewBag.DataPoints = JsonConvert.SerializeObject(_context.v_nemudar_never_bakhsh.Where(s=>s.hos_id==hos_id), _jsonSetting);
            return View();
        }



        public async Task<IActionResult> tedad_never()
        {
            var eye_nobatContext = _context.never.Include(n => n.bakhsh).Include(n => n.code).Include(n => n.jensiat);
            if (HttpContext.Session.GetString("rule") == "bakhsh")
            {
                eye_nobatContext = _context.never.Where(s => s.bakhsh_id == long.Parse(HttpContext.Session.GetString("id"))).Include(n => n.bakhsh).Include(n => n.code).Include(n => n.jensiat);
            }
            return View(await eye_nobatContext.ToListAsync());
        }
        public async Task<IActionResult> tedad_code()
        {
            return _context.uni != null ?
                        View(await _context.code.ToListAsync()) :
                        Problem("Entity set 'eye_nobatContext.code'  is null.");
        }
        public async Task<IActionResult> tedad_hos()
        {
            if (HttpContext.Session.GetString("rule") == "admin")
            {
 return _context.v_nemudar_never_hos != null ?
                        View(await _context.v_nemudar_never_hos.ToListAsync()) :
                        Problem("Entity set 'eye_nobatContext.hos'  is null.");
            }
            else if (HttpContext.Session.GetString("rule") == "uni")
            {
                return _context.v_nemudar_never_hos != null ?
                                       View(await _context.v_nemudar_never_hos.Where(s=>s.uni_id== long.Parse(HttpContext.Session.GetString("id"))).ToListAsync()) :
                                       Problem("Entity set 'eye_nobatContext.hos'  is null.");
            }

            else
            {
                return RedirectToAction("login", "admins");
            }

        }
        public async Task<IActionResult> tedad_uni()
        {
            return _context.v_nemudar_never_uni != null ?
                        View(await _context.v_nemudar_never_uni.ToListAsync()) :
                        Problem("Entity set 'eye_nobatContext.uni'  is null.");
        }

        public async Task<IActionResult> tedad_modiran()
        {
            return _context.admin != null ?
                          View(await _context.admin.ToListAsync()) :
                          Problem("Entity set 'eye_nobatContext.admin'  is null.");
        }
        public async Task<IActionResult> tedad_paye()
        {
            var q1 = _context.admin.AsNoTracking().ToList();
            ViewBag.admin_count = q1.Count();

            var q2 = _context.uni.AsNoTracking().ToList();
            ViewBag.uni_count = q2.Count();

            var q3 = _context.hos.AsNoTracking().ToList();
            ViewBag.hos_count = q3.Count();

            var q4 = _context.bakhsh.AsNoTracking().ToList();
            ViewBag.bakhsh_count = q4.Count();

            var q5 = _context.code.AsNoTracking().ToList();
            ViewBag.code_count = q5.Count();

            var q6 = _context.never.AsNoTracking().ToList();
            ViewBag.never_count = q6.Count();

            return View();
        }
        public async Task<IActionResult> search_bakhsh()
        {

                ViewData["bakhsh_name"] = new SelectList(_context.v_bakhsh_g, "name", "name");
                return View();

        }

        [HttpPost]
        public async Task<IActionResult> searched_bakhsh(string? bakhsh_name)
        {
            if (HttpContext.Session.GetString("rule") == "admin")
            {
                var q = _context.v_koli_detail.ToList();
                if (bakhsh_name != "null")
                {
                    q = q.Where(s => s.bakhsh_name == bakhsh_name).ToList();
                }

                return View(q.ToList());
            }
            else if (HttpContext.Session.GetString("rule") == "uni")
            {
                var q1 = _context.v_koli_detail.Where(s => s.uni_id == long.Parse(HttpContext.Session.GetString("id"))).ToList();
                if (bakhsh_name != "null")
                {
                    q1 = q1.Where(s => s.bakhsh_name == bakhsh_name).ToList();
                }

                return View(q1.ToList());
            }
            else if (HttpContext.Session.GetString("rule") == "hos")
            {
                var q1 = _context.v_koli_detail.Where(s => s.hos_id == long.Parse(HttpContext.Session.GetString("id"))).ToList();
                if (bakhsh_name != "null")
                {
                    q1 = q1.Where(s => s.bakhsh_name == bakhsh_name).ToList();
                }
                return View(q1.ToList());
            }
            else if (HttpContext.Session.GetString("rule") == "bakhsh")
            {
                var q1 = _context.v_koli_detail.Where(s => s.bakhsh_id == long.Parse(HttpContext.Session.GetString("id"))).ToList();
                if (bakhsh_name != "null")
                {
                    q1 = q1.Where(s => s.bakhsh_name == bakhsh_name).ToList();
                }
                return View(q1.ToList());
            }
            else
            {
                return RedirectToAction("login", "admins");
            }

        }

        public async Task<IActionResult> search_hos()
        {
            if (HttpContext.Session.GetString("rule") == "admin")
            {
                ViewData["hos_id"] = new SelectList(_context.hos, "id", "name");
                return View();
            }
            else if (HttpContext.Session.GetString("rule") == "uni")
            {
                ViewData["hos_id"] = new SelectList(_context.hos.Where(s=>s.uni_id== long.Parse(HttpContext.Session.GetString("id"))), "id", "name");
                return View();
            }
            else
            {
                return RedirectToAction("login", "admins");
            }
        }

        [HttpPost]
        public async Task<IActionResult> searched_hos(long? hos_id)
        {
            var q = _context.v_koli_detail.ToList();
            if (HttpContext.Session.GetString("rule") == "admin")
            {
                if (hos_id != null)
                {
                    q = q.Where(s => s.hos_id == hos_id).ToList();
                }
            }
            else if (HttpContext.Session.GetString("rule") == "uni")
            {
                q = q.Where(s => s.uni_id == long.Parse(HttpContext.Session.GetString("id"))).ToList();
                if (hos_id != null)
                {
                    q = q.Where(s => s.hos_id == hos_id).ToList();
                }
            }



            return View(q.ToList());
        }

        public async Task<IActionResult> search_uni()
        {
            ViewData["uni_id"] = new SelectList(_context.uni, "id", "name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> searched_uni(long? uni_id)
        {
            var q = _context.v_koli_detail.ToList();
            if (uni_id != null)
            {
                q = q.Where(s => s.uni_id == uni_id).ToList();
            }

            return View(q.ToList());
        }

        public async Task<IActionResult> search()
        {
            ViewData["code_id"] = new SelectList(_context.code, "id", "name");
            ViewData["jensiat_id"] = new SelectList(_context.jensiat, "id", "name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> searched(long? code_id, string? flname, string? codemeli, string? sen, long? jensiat_id, string? date_morajee, string? saat_morajee, string? date_voghu, string? saat_voghu)
        {
            if (HttpContext.Session.GetString("rule") == "admin")
            {
                var q = _context.v_koli_detail.ToList();
                if (code_id != null)
                {
                    q = q.Where(s => s.code_id == code_id).ToList();
                }
                if (flname != null)
                {
                    q = q.Where(s => s.flname == flname).ToList();
                }
                if (codemeli != null)
                {
                    q = q.Where(s => s.codemeli == codemeli).ToList();
                }
                if (sen != null)
                {
                    q = q.Where(s => s.sen == sen).ToList();
                }
                if (jensiat_id != null)
                {
                    q = q.Where(s => s.jensiat_id == jensiat_id).ToList();
                }
                if (date_morajee != null)
                {
                    q = q.Where(s => s.date_morajee == date_morajee).ToList();
                }
                if (saat_morajee != null)
                {
                    q = q.Where(s => s.saat_morajee == saat_morajee).ToList();
                }
                if (date_voghu != null)
                {
                    q = q.Where(s => s.date_voghu == date_voghu).ToList();
                }
                if (saat_voghu != null)
                {
                    q = q.Where(s => s.saat_voghu == saat_voghu).ToList();
                }
                return View(q.ToList());
            }
            else if (HttpContext.Session.GetString("rule") == "uni")
            {
                var q = _context.v_koli_detail.Where(s=>s.uni_id==long.Parse(HttpContext.Session.GetString("id"))).ToList();
                if (code_id != null)
                {
                    q = q.Where(s => s.code_id == code_id).ToList();
                }
                if (flname != null)
                {
                    q = q.Where(s => s.flname == flname).ToList();
                }
                if (codemeli != null)
                {
                    q = q.Where(s => s.codemeli == codemeli).ToList();
                }
                if (sen != null)
                {
                    q = q.Where(s => s.sen == sen).ToList();
                }
                if (jensiat_id != null)
                {
                    q = q.Where(s => s.jensiat_id == jensiat_id).ToList();
                }
                if (date_morajee != null)
                {
                    q = q.Where(s => s.date_morajee == date_morajee).ToList();
                }
                if (saat_morajee != null)
                {
                    q = q.Where(s => s.saat_morajee == saat_morajee).ToList();
                }
                if (date_voghu != null)
                {
                    q = q.Where(s => s.date_voghu == date_voghu).ToList();
                }
                if (saat_voghu != null)
                {
                    q = q.Where(s => s.saat_voghu == saat_voghu).ToList();
                }
                return View(q.ToList());
            }
            else if (HttpContext.Session.GetString("rule") == "hos")
            {
                var q = _context.v_koli_detail.Where(s => s.hos_id == long.Parse(HttpContext.Session.GetString("id"))).ToList();
                if (code_id != null)
                {
                    q = q.Where(s => s.code_id == code_id).ToList();
                }
                if (flname != null)
                {
                    q = q.Where(s => s.flname == flname).ToList();
                }
                if (codemeli != null)
                {
                    q = q.Where(s => s.codemeli == codemeli).ToList();
                }
                if (sen != null)
                {
                    q = q.Where(s => s.sen == sen).ToList();
                }
                if (jensiat_id != null)
                {
                    q = q.Where(s => s.jensiat_id == jensiat_id).ToList();
                }
                if (date_morajee != null)
                {
                    q = q.Where(s => s.date_morajee == date_morajee).ToList();
                }
                if (saat_morajee != null)
                {
                    q = q.Where(s => s.saat_morajee == saat_morajee).ToList();
                }
                if (date_voghu != null)
                {
                    q = q.Where(s => s.date_voghu == date_voghu).ToList();
                }
                if (saat_voghu != null)
                {
                    q = q.Where(s => s.saat_voghu == saat_voghu).ToList();
                }
                return View(q.ToList());
            }
            else if (HttpContext.Session.GetString("rule") == "bakhsh")
            {
                var q = _context.v_koli_detail.Where(s => s.bakhsh_id == long.Parse(HttpContext.Session.GetString("id"))).ToList();
                if (code_id != null)
                {
                    q = q.Where(s => s.code_id == code_id).ToList();
                }
                if (flname != null)
                {
                    q = q.Where(s => s.flname == flname).ToList();
                }
                if (codemeli != null)
                {
                    q = q.Where(s => s.codemeli == codemeli).ToList();
                }
                if (sen != null)
                {
                    q = q.Where(s => s.sen == sen).ToList();
                }
                if (jensiat_id != null)
                {
                    q = q.Where(s => s.jensiat_id == jensiat_id).ToList();
                }
                if (date_morajee != null)
                {
                    q = q.Where(s => s.date_morajee == date_morajee).ToList();
                }
                if (saat_morajee != null)
                {
                    q = q.Where(s => s.saat_morajee == saat_morajee).ToList();
                }
                if (date_voghu != null)
                {
                    q = q.Where(s => s.date_voghu == date_voghu).ToList();
                }
                if (saat_voghu != null)
                {
                    q = q.Where(s => s.saat_voghu == saat_voghu).ToList();
                }
                return View(q.ToList());
            }
            else
            {
                return RedirectToAction("login", "admins");
            }





        }
        public async Task<IActionResult> v_ertebat_marakez()
        {
            var q = _context.v_ertebat_marakez;
            return View(await q.ToListAsync());
        }

        // GET: nevers
        public async Task<IActionResult> Index()
        {
            var eye_nobatContext = _context.never.Include(n => n.bakhsh).Include(n => n.code).Include(n => n.jensiat);
            ViewData["bakhsh_id"] = new SelectList(_context.bakhsh.Where(s => s.id == long.Parse(HttpContext.Session.GetString("id"))), "id", "name");
            ViewData["code_id"] = new SelectList(_context.code, "id", "name");
            ViewData["jensiat_id"] = new SelectList(_context.jensiat, "id", "name");
            if (HttpContext.Session.GetString("rule") == "bakhsh")
            {
                eye_nobatContext = _context.never.Where(s => s.bakhsh_id == long.Parse(HttpContext.Session.GetString("id"))).Include(n => n.bakhsh).Include(n => n.code).Include(n => n.jensiat);
            }
            return View(await eye_nobatContext.ToListAsync());
        }

        // GET: nevers/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.never == null)
            {
                return NotFound();
            }

            var never = await _context.never
                .Include(n => n.bakhsh)
                .Include(n => n.code)
                .Include(n => n.jensiat)
                .FirstOrDefaultAsync(m => m.id == id);
            if (never == null)
            {
                return NotFound();
            }

            return View(never);
        }

        public async Task<IActionResult> Details_search(long? id)
        {
            if (id == null || _context.never == null)
            {
                return NotFound();
            }

            var never = await _context.never
                .Include(n => n.bakhsh)
                .Include(n => n.code)
                .Include(n => n.jensiat)
                .FirstOrDefaultAsync(m => m.id == id);
            if (never == null)
            {
                return NotFound();
            }

            return View(never);
        }

        // GET: nevers/Create
        public IActionResult Create()
        {
            ViewData["bakhsh_id"] = new SelectList(_context.bakhsh.Where(s => s.id == long.Parse(HttpContext.Session.GetString("id"))), "id", "name");
            ViewData["code_id"] = new SelectList(_context.code, "id", "name");
            ViewData["jensiat_id"] = new SelectList(_context.jensiat, "id", "name");
            return View();
        }

        // POST: nevers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,bakhsh_id,code_id,flname,codemeli,sen,jensiat_id,date_morajee,saat_morajee,date_voghu,saat_voghu,tozihat")] never never)
        {

            _context.Add(never);
            await _context.SaveChangesAsync();
            ////================================================sms
            //var q = _context.code.AsNoTracking().Where(s => s.num == never.code_id).FirstOrDefault();
            //if (q.sms == true)
            //{
            //    var e = _context.user.AsNoTracking().Where(s => s.id_user == never_asli.id_user).FirstOrDefault();
            //    Int64 id_bakhsh = e.id_bakhsh;
            //    var r = _context.bakhsh.AsNoTracking().Where(s => s.id_bakhsh == id_bakhsh).FirstOrDefault();
            //    var client = new AmootSMS.AmootSMSWebService2SoapClient(
            //     AmootSMS.AmootSMSWebService2SoapClient.EndpointConfiguration.AmootSMSWebService2Soap12,
            //     "https://portal.amootsms.com/webservice2.asmx");
            //    string UserName = "09127784722";
            //    string Password = "@Alireza17439";
            //    DateTime SendDateTime = DateTime.Now;

            //    var w = _context.mobile.AsNoTracking().ToList();
            //    string[] Mobiles = new string[w.Count];
            //    for (int i = 0; i < w.Count; i++)
            //    {

            //        Mobiles[i] = w[i].num_mobile.ToString();

            //    }
            //    string SMSMessageText = "Never Event: " + " خطا با شماره " + " " + " توسط بخش" + " " + never_asli.num_khata + r.name_bakhsh + " ثبت شد";
            //    string LineNumber = "Service";
            //    // AmootSMS.AmootSMSWebService2SoapClient client = new AmootSMS.AmootSMSWebService2SoapClient("AmootSMSWebService2Soap12");

            //    AmootSMS.SendResult result = client.SendSimpleAsync(UserName, Password, SendDateTime, SMSMessageText, LineNumber, Mobiles).Result;

            //    if (result.Status == AmootSMS.Status.Success)
            //    {
            //        sentsms sentsms = new sentsms();
            //        sentsms.status = "موفق";
            //        sentsms.id_never = never_asli.id_never;
            //        sentsms.id_user = never_asli.id_user;
            //        _context.Add(sentsms);
            //        await _context.SaveChangesAsync();
            //        _context.Entry(sentsms).State = EntityState.Detached;
            //    }
            //}
            ////================================================sms

            return RedirectToAction(nameof(Index));

        }

        // GET: nevers/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.never == null)
            {
                return NotFound();
            }

            var never = await _context.never.FindAsync(id);
            if (never == null)
            {
                return NotFound();
            }
            ViewData["bakhsh_id"] = new SelectList(_context.bakhsh.Where(s => s.id == long.Parse(HttpContext.Session.GetString("id"))), "id", "name", never.bakhsh_id);
            ViewData["code_id"] = new SelectList(_context.code, "id", "name", never.code_id);
            ViewData["jensiat_id"] = new SelectList(_context.jensiat, "id", "name", never.jensiat_id);
            return View(never);
        }

        // POST: nevers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("id,bakhsh_id,code_id,flname,codemeli,sen,jensiat_id,date_morajee,saat_morajee,date_voghu,saat_voghu,tozihat")] never never)
        {
            if (id != never.id)
            {
                return NotFound();
            }


            try
            {
                _context.Update(never);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!neverExists(never.id))
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

        // GET: nevers/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.never == null)
            {
                return NotFound();
            }

            var never = await _context.never
                .Include(n => n.bakhsh)
                .Include(n => n.code)
                .Include(n => n.jensiat)
                .FirstOrDefaultAsync(m => m.id == id);
            if (never == null)
            {
                return NotFound();
            }

            return View(never);
        }

        // POST: nevers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.never == null)
            {
                return Problem("Entity set 'eye_nobatContext.never'  is null.");
            }
            var never = await _context.never.FindAsync(id);
            if (never != null)
            {
                _context.never.Remove(never);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool neverExists(long id)
        {
            return (_context.never?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
