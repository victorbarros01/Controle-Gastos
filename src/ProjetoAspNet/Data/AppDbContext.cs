using Microsoft.EntityFrameworkCore;
using ProjetoAspNet.Models;
using ProjetoAspNet.Models.BankExpense;
using ProjetoAspNet.Models.Expense_Management;
namespace ProjetoAspNet.Data {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<TaskGroup> TasksGroup { get; set; }
        public DbSet<Statement> Statements { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Earning> Earnings { get; set; }

    }
}
