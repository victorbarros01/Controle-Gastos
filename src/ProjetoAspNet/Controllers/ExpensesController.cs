using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using ProjetoAspNet.Data;
using ProjetoAspNet.Models;

namespace ProjetoAspNet.Controllers {
    public class ExpensesController : Controller{
        private readonly AppDbContext _context;

        public ExpensesController(AppDbContext context) {
            _context = context; 
        }

        public IActionResult Index() {
                       return View(_context.Expenses.ToList());
        }

        public IActionResult Create() {
                       return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Expense expense) {
            
            if(ModelState.IsValid) {
                _context.Add(expense);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }


    }
}
