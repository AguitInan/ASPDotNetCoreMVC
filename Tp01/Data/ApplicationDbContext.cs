using Microsoft.EntityFrameworkCore;
using Tp01.Models;

namespace Tp01.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\demo01ado;Database=todo_item;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            int _lastId = 0; // pour faire un équivalent d'IDENTITY ou AUTO INCREMENT

            modelBuilder.Entity<TodoItem>().HasData(
                    new TodoItem { Id = ++_lastId, Title = "Courses", Description = "Faire les courses", IsCompleted = false },
                    new TodoItem { Id = ++_lastId, Title = "Vaisselle", Description = "Faire la vaisselle", IsCompleted = true }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
