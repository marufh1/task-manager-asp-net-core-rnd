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
    public class TasksController : Controller
    {
        private readonly TASKDBContext _context;

        public TasksController(TASKDBContext context)
        {
            _context = context;
        }

        // GET: Tasks
        public async Task<IActionResult> Index2()
        {
            //var b = _context.Resinfs
            var a = _context.Tasks1s.ToListAsync();

            return View(await a);
        }

        public async Task<IActionResult> Index()
        {
            string d = "TASKS_INF01";
            int i = 1;
            var b = (await _context.MyTasks1.FromSqlRaw("Exec SP_BMANAGE_INFO_REPORT_01 @ProcessID = '" + d + "'").ToListAsync());
            //  var a = _context.Tasks1s.ToListAsync();
            return View(b);
        }

        public async Task<IActionResult> Completed()
        {
            string d = "TASKS_INF01";
            int i = 1;
            var b = (await _context.MyTasks1.FromSqlRaw("Exec SP_BMANAGE_INFO_REPORT_01 @ProcessID = '" + d + "'").ToListAsync()).Where(x => x.Tskstatus == "completed");
            //  var a = _context.Tasks1s.ToListAsync();
            return View(b);
        }

        public async Task<IActionResult> Pending()
        {
            string d = "TASKS_INF01";
            int i = 1;
            var b = (await _context.MyTasks1.FromSqlRaw("Exec SP_BMANAGE_INFO_REPORT_01 @ProcessID = '" + d + "'").ToListAsync()).Where(x => x.Tskstatus == "pending");
            //  var a = _context.Tasks1s.ToListAsync();
            return View(b);
        }


        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tasks1 = await _context.Tasks1s
                .FirstOrDefaultAsync(m => m.Tskid == id);
            if (tasks1 == null)
            {
                return NotFound();
            }

            return View(tasks1);
        }

        // GET: Tasks/Create
        public IActionResult Create()
        {
            string procId = "RESOURCE_INF01";
            ViewData["resInf"] = _context.Resinfs.FromSqlRaw("Exec SP_BMANAGE_INFO_REPORT_01 @ProcessID = '" + procId + "'").ToList();
            ViewData["projects"] = _context.Projectds.FromSqlRaw("Exec SP_BMANAGE_INFO_REPORT_01 @ProcessID = 'PROJECTS_INF01'").ToList();

            //       ViewData["projects"] = _context.Resinfs.ToList();

            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tasks1 tasks1)
        {
            if (ModelState.IsValid)
            {

                if (tasks1.Tskowner == null)
                {
                    tasks1.Tskowner = "000000000000";
                }

                var lastId = _context.MyTasks1.Max(p => p.Tskid).ToString().Substring(8, 4);
                string id = (Convert.ToInt32(lastId) + 1).ToString("0000");
                string tskId = DateTime.Now.ToString("MMdd") + tasks1.Tskproject.Substring(6, 4) + id;
                tasks1.Tskid = tskId;
                _context.Add(tasks1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tasks1);
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            string procId = "RESOURCE_INF01";
            ViewData["resInf"] = _context.Resinfs.FromSqlRaw("Exec SP_BMANAGE_INFO_REPORT_01 @ProcessID = '" + procId + "'").ToList();
            ViewData["projects"] = _context.Projectds.FromSqlRaw("Exec SP_BMANAGE_INFO_REPORT_01 @ProcessID = 'PROJECTS_INF01'").ToList();


            var tasks1 = await _context.Tasks1s.FindAsync(id);
            if (tasks1 == null)
            {
                return NotFound();
            }
            return View(tasks1);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Tasks1 tasks1)
        {
            if (id != tasks1.Tskid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var lastId = _context.MyTasks1.Max(p => p.Rowid);
                    int id3 = Convert.ToInt32(lastId) + 1;

                    if (tasks1.Tskdesc == null)
                    {
                        tasks1.Tskdesc = "";
                    }

                    //tasks1.Rowtime = DateTime.Now;

                    // var maxItem = _context.MyTasks1.OrderByDescending(i => i.Rowid).FirstOrDefault();
                    //  var newID = maxItem == null ? 1 : maxItem.Rowid + 1;


                    string procId = "RESOURCE_INF01";
                    ViewData["resInf"] = _context.Resinfs.FromSqlRaw("Exec SP_BMANAGE_INFO_REPORT_01 @ProcessID = '" + procId + "'").ToList();
                    ViewData["projects"] = _context.Projectds.FromSqlRaw("Exec SP_BMANAGE_INFO_REPORT_01 @ProcessID = 'PROJECTS_INF01'").ToList();


                    _context.Update(tasks1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!Tasks1Exists(tasks1.Tskid))
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
            return View(tasks1);
        }

        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tasks1 = await _context.Tasks1s
                .FirstOrDefaultAsync(m => m.Tskid == id);
            if (tasks1 == null)
            {
                return NotFound();
            }

            return View(tasks1);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tasks1 = await _context.Tasks1s.FindAsync(id);
            _context.Tasks1s.Remove(tasks1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Tasks1Exists(string id)
        {
            return _context.Tasks1s.Any(e => e.Tskid == id);
        }
    }
}
