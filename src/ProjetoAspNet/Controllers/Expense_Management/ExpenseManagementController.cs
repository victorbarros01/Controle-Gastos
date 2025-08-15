using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoAspNet.Data;
using ProjetoAspNet.Models.Expense_Management;
using ProjetoAspNet.ViewModel;
using System.Data;

namespace ProjetoAspNet.Controllers.Expense_Management {
    public class ExpenseManagementController : Controller{
        private readonly AppDbContext _context;
        public ExpenseManagementController(AppDbContext context) {
            _context = context; 
        }


        [HttpGet]
        public async Task<IActionResult> Index() {
            var expenseManagementListVM = new List<ExpenseManagementViewModel>();
            
            var expenses = await _context.Expenses.ToListAsync();
            foreach (var ep in expenses) {
                var expenseVM = new ExpenseManagementViewModel {
                    
                    AmountExpense = ep.Amount,
                    DescriptionExpense = ep.Description,
                    IsFixedExpense = ep.IsFixed
                };                
                expenseManagementListVM.Add(expenseVM);
            }

            var earnings = await _context.Earnings.ToListAsync();
            foreach (var er in earnings) {
                var earningVM = new ExpenseManagementViewModel {
                    
                    AmountEarning = er.Amount,
                    DescriptionEarning = er.Description,
                    IsFixedEarning = er.IsFixed
                };
                expenseManagementListVM.Add(earningVM);
            }

            return View(expenseManagementListVM);
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

        [HttpPost] // Metodo de rota nulo pois não irá retornar tela e irá apenas apagar o item ao selecionar em um modal, sendo função do front a parte de "redirecionar" a orientação de tela
        public async void DeleteExpense(int id) {
            var expense = await _context.Expenses.FindAsync(id);
            if(ModelState.IsValid){
                if (expense != null) {
                    _context.Expenses.Remove(expense);
                    await _context.SaveChangesAsync();
                } else {
                    throw new Exception("expense é nulo");
                }
            } else {
               throw new Exception("Erro no ModelState");
            }
        }

        [HttpPost] // Metodo de rota nulo pois não irá retornar tela e irá apenas apagar o item ao selecionar em um modal, sendo função do front a parte de "redirecionar" a orientação de tela
        public async void DeleteEarning(int id) {
            var earning = await _context.Earnings.FindAsync(id);
            if (ModelState.IsValid) {
                if (earning != null) {
                    _context.Earnings.Remove(earning);
                    await _context.SaveChangesAsync();
                } else {
                    throw new Exception("expense é nulo");
                }
            } else {
                throw new Exception("Erro no ModelState");
            }
        }
    }
}
