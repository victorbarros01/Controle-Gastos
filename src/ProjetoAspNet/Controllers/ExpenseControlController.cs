using Microsoft.AspNetCore.Mvc;
using ProjetoAspNet.Data;

namespace ProjetoAspNet.Controllers {
    public class ExpenseControlController : Controller{
        private readonly AppDbContext _context;
        public ExpenseControlController(AppDbContext context) {
            _context = context; 
        }
        
        public IActionResult Index() {

            return View();
            // Trazer A lógica para exibir as despesas os ganhos e o saldo.
        }
    }
}
