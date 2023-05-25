using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using never_vezarat.Data;
using never_vezarat.Models;

namespace never_vezarat.Controllers
{
    public class usersController : Controller
    {
        private readonly never_vezaratContext _context;

        public usersController(never_vezaratContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> main_user()
        {
            return View();
        }

      



        // GET: users
        public async Task<IActionResult> Index()
        {
              return _context.user != null ? 
                          View(await _context.user.ToListAsync()) :
                          Problem("Entity set 'never_vezaratContext.user' is null.");
        }





        // GET: users/Create
        public IActionResult Create()
        {
            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("user_id,flname,username,userpass,admin")] user user)
        {
            var q = await _context.uni.AsNoTracking().Where(s => s.uname == user.upass).ToListAsync();
            if (q.Count != 0) 
            {
                TempData["tekrari"] = "1";
                return View();
            }



            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.user == null)
            {
                return NotFound();
            }

            var user = await _context.user.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            TempData["admin"] = user.admin;
            return View(user);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("user_id,flname,username,userpass,admin")] user user)
        {
            if (id != user.user_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!userExists(user.user_id))
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
            return View(user);
        }

        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.user == null)
            {
                return NotFound();
            }

            var user = await _context.user
                .FirstOrDefaultAsync(m => m.user_id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.user == null)
            {
                return Problem("Entity set 'never_vezaratContext.user'  is null.");
            }
            var user = await _context.user.FindAsync(id);
            if (user != null)
            {
                _context.user.Remove(user);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool userExists(long id)
        {
          return (_context.user?.Any(e => e.user_id == id)).GetValueOrDefault();
        }
    }
}
