using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoAspNet.Data;
using ProjetoAspNet.Models;
using ProjetoAspNet.Service;
using System.Security.Claims;

namespace ProjetoAspNet.Controllers {
    public class UsersController : Controller {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context) {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index(int? id) {
            var user = await _context.Users.FindAsync(id);

            return View(await _context.Users.ToListAsync());
        }

        // GET: Login
        public IActionResult Login() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string userName, string password) {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == userName);

            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password)) {
                var token = new TokenService();
                token.Generate(user);
                Console.WriteLine(token.Generate(user));
                var principal = new ClaimsPrincipal(TokenService.GenerateClaims(user));
                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Home");
            }

            return View();
        }


        // GET: Users/Create
        public IActionResult SignUp() {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp([Bind("UserId,Username,Email,Password")] User user) {

            if (user == null) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                var newUser = new User(user.Username, user.Email, user.Password);
                _context.Add(newUser);
                await _context.SaveChangesAsync();
                TempData["UserId"] = newUser.UserId;
                return RedirectToAction(nameof(VerifyEmail));
            } else {
                new Exception("Errorrrr");
            }
            return View();
        }


        public async Task<IActionResult> VerifyEmail() {

            var id = TempData["UserId"];

            ViewBag.UserId = id;
            var user = await _context.Users.FindAsync(id);
            if (user != null) {
                SendEmail(user.Email, user.Code);
                return View();
            }

            return RedirectToAction(nameof(SignUp));

        }

        private async void SendEmail(string email, int code) {
            var sendEmail = new SendCodeInEmailService(email, code);
            await sendEmail.SendEmailAsync();
        }

        [HttpPost]
        public async Task<IActionResult> VerifyEmail(int code, int id) {
            var user = await _context.Users.FindAsync(id);

            if (user != null && ModelState.IsValid) {
                var count = 0;
                var validEmail = VerifyEmailService.VerifyEmail(code, user.Code);

                if (count >= 3) {
                    _context.Users.Remove(user);
                    new Exception("Devido ter esgotados as tentativas, você terá que alterar seu email e tentar novamente!");

                    return RedirectToAction(nameof(SignUp));
                } else {
                    //Comparar código pra válidar a conta
                    if (validEmail == true) {
                        return RedirectToAction(nameof(Login));
                    } else {
                        ++count;
                        new Exception($"Código inválido, você tem mais {count - 3} tentativas");
                    }
                }
            } else {
                new Exception("Deu Erro Não Achou o User: " + user);
            }
            return View();
        }

        public IActionResult Logout() {
            return View();
        }

        public IActionResult AccessDenied() {
            return View();
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id) {
            if (id == null) {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null) {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Username,Email,Password")] User user) {
            if (id != user.UserId) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException) {
                    if (!UserExists(user.UserId)) {
                        return NotFound();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id) {
            if (id == null) {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null) {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            var user = await _context.Users.FindAsync(id);
            if (user != null) {
                _context.Users.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id) {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
