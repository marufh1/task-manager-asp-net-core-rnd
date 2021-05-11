using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TASKMANAGER21.Models;

namespace TASKMANAGER21.Controllers
{
    public class UserController : Controller
    {
        private readonly TASKDBContext _context;

        public UserController(TASKDBContext context)
        {
            _context = context;
        }

        // GET: Resinfs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Resinfs.ToListAsync());
        }

        // GET: Resinfs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resinf = await _context.Resinfs
                .FirstOrDefaultAsync(m => m.Rescode == id);
            if (resinf == null)
            {
                return NotFound();
            }

            return View(resinf);
        }

        // GET: Resinfs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Resinfs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Resinf resinf)
        {
            if (ModelState.IsValid)
            {
                string usrType = resinf.Restype.ToLower() == "admin" ? "30" : "60";
                var lastId2 = _context.Resinfs.Where(x => x.Rescode.Substring(6, 2) == usrType).Max(p => p.Rescode).Substring(8, 4);
                var lastId = _context.Resinfs.Max(p => p.Rescode).ToString().Substring(8, 4);
                string id = (Convert.ToInt32(lastId2) + 1).ToString("0000");
                resinf.Rescode = DateTime.Now.ToString("yyMMdd") + usrType + id;
                
                _context.Add(resinf);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(resinf);
        }

        // GET: Resinfs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resinf = await _context.Resinfs.FindAsync(id);
            if (resinf == null)
            {
                return NotFound();
            }
            return View(resinf);
        }

        // POST: Resinfs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Resinf resinf)
        {
            if (id != resinf.Rescode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resinf);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResinfExists(resinf.Rescode))
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
            return View(resinf);
        }

        // GET: Resinfs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resinf = await _context.Resinfs
                .FirstOrDefaultAsync(m => m.Rescode == id);
            if (resinf == null)
            {
                return NotFound();
            }

            return View(resinf);
        }

        // POST: Resinfs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var resinf = await _context.Resinfs.FindAsync(id);
            _context.Resinfs.Remove(resinf);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResinfExists(string id)
        {
            return _context.Resinfs.Any(e => e.Rescode == id);
        }
    }
}
