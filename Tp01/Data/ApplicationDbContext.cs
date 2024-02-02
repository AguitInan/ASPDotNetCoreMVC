using Microsoft.EntityFrameworkCore;
using Tp01.Models;

namespace Tp01.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<TodoItem> TodoItems { get; set; }



    }
}
