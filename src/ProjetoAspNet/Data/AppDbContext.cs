using Microsoft.EntityFrameworkCore;
using ProjetoAspNet.Models;
namespace ProjetoAspNet.Data {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<TaskGroup> TasksGroup { get; set; }


    }
}
