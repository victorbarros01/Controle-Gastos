using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoAspNet.Data;
using ProjetoAspNet.Models;

namespace ProjetoAspNet.Controllers {
    public class TasksGroupController : Controller {
        private readonly AppDbContext _context;

        public TasksGroupController(AppDbContext context) {
            _context = context;
        }

        // GET: TasksGroup
        public async Task<IActionResult> Index() {
            var appDbContext = _context.TasksGroup.Include(t => t.User);
            return View(await appDbContext.ToListAsync());
        }

        // GET: TasksGroup/Details/5
        public async Task<IActionResult> Details(int? id) {
            if (id == null) {
                return NotFound();
            }

            var taskGroup = await _context.TasksGroup
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.TaskId == id);
            if (taskGroup == null) {
                return NotFound();
            }

            return View(taskGroup);
        }

        // GET: TasksGroup/Create
        public IActionResult Create() {
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email");
            return View();
        }

        // POST: TasksGroup/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaskId,Name,Description,UserId")] TaskGroup taskGroup) {
            if (ModelState.IsValid) {

                _context.Add(taskGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email", taskGroup.UserId);
            return View(taskGroup);
        }

        // GET: TasksGroup/Edit/5
        public async Task<IActionResult> Edit(int? id) {
            if (id == null) {
                return NotFound();
            }

            var taskGroup = await _context.TasksGroup.FindAsync(id);
            if (taskGroup == null) {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email", taskGroup.UserId);
            return View(taskGroup);
        }

        // POST: TasksGroup/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaskId,Name,Description,Status,UserId")] TaskGroup taskGroup) {
            if (id != taskGroup.TaskId) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(taskGroup);
                    await _context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException) {
                    if (!TaskGroupExists(taskGroup.TaskId)) {
                        return NotFound();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email", taskGroup.UserId);
            return View(taskGroup);
        }

        // GET: TasksGroup/Delete/5
        public async Task<IActionResult> Delete(int? id) {
            if (id == null) {
                return NotFound();
            }

            var taskGroup = await _context.TasksGroup
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.TaskId == id);
            if (taskGroup == null) {
                return NotFound();
            }

            return View(taskGroup);
        }

        // POST: TasksGroup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            var taskGroup = await _context.TasksGroup.FindAsync(id);
            if (taskGroup != null) {
                _context.TasksGroup.Remove(taskGroup);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskGroupExists(int id) {
            return _context.TasksGroup.Any(e => e.TaskId == id);
        }
    }
}
