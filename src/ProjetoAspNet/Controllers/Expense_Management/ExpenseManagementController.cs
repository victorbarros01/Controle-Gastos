using Microsoft.AspNetCore.Mvc;
using ProjetoAspNet.Data;
using ProjetoAspNet.Models.Expense_Management;
using System.Data;

namespace ProjetoAspNet.Controllers.Expense_Management {
    public class ExpenseManagementController : Controller{
        private readonly AppDbContext _context;
        public ExpenseManagementController(AppDbContext context) {
            _context = context; 
        }


        [HttpGet]
        public IActionResult Index() {
            ViewData["Earnings"] = _context.Earnings.ToList();
            ViewData["Expenses"] = _context.Expenses.ToList();
            
            return View();
            // Trazer A lógica para exibir as despesas os ganhos e o saldo.
        }

        [HttpGet]
        public IActionResult CreateEarning() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEarning(Earning er) {
            if (ModelState.IsValid) {
                var earning = new Earning(er.Amount, er.Description, er.IsFixed);
                _context.Earnings.Add(earning);
                await _context.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateExpense() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateExpense(Expense ep) {
            if (ModelState.IsValid) {
                var expense = new Expense(ep.Amount, ep.Description, ep.IsFixed);
                _context.Expenses.Add(expense);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
