using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoAspNet.Data;
using ProjetoAspNet.Models;
namespace ProjetoAspNet.Controllers {

    public class EarningsController : Controller {
        private readonly AppDbContext _context;

        public EarningsController(AppDbContext context) {
            _context = context;
        }

        // GET: Earnings
        public IActionResult Index() {
            return View(_context.Earnings.ToList());
        }

        public IActionResult Create() {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create (Earning earning){

            if (ModelState.IsValid) {
                _context.Add(earning);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
    }
}
