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
    public class ProjectsController : Controller
    {
        private readonly TASKDBContext _context;

        public ProjectsController(TASKDBContext context)
        {
            _context = context;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            return View(await _context.Projectds.ToListAsync());
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectd = await _context.Projectds
                .FirstOrDefaultAsync(m => m.Prid == id);
            if (projectd == null)
            {
                return NotFound();
            }

            return View(projectd);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Projectd projectd)
        {
            if (ModelState.IsValid)
            {

                var lastId = _context.Projectds.Max(p => p.Prid).ToString().Substring(6, 4);
                string id = (Convert.ToInt32(lastId) + 1).ToString("0000");
                string prjId = DateTime.Now.ToString("yyMMdd") + id;
                projectd.Prid = prjId;

                _context.Add(projectd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projectd);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectd = await _context.Projectds.FindAsync(id);
            if (projectd == null)
            {
                return NotFound();
            }
            return View(projectd);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Prid,Prname,Prdesc")] Projectd projectd)
        {
            if (id != projectd.Prid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectdExists(projectd.Prid))
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
            return View(projectd);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectd = await _context.Projectds
                .FirstOrDefaultAsync(m => m.Prid == id);
            if (projectd == null)
            {
                return NotFound();
            }

            return View(projectd);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var projectd = await _context.Projectds.FindAsync(id);
            _context.Projectds.Remove(projectd);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectdExists(string id)
        {
            return _context.Projectds.Any(e => e.Prid == id);
        }
    }
}
