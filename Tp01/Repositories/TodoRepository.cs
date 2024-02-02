using System.Linq.Expressions;
using Tp01.Data;
using Tp01.Models;

namespace Tp01.Repositories
{
    public class TodoRepository : IRepository<TodoItem>
    {
        private readonly ApplicationDbContext _dbContext;
        public TodoRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }









    }
}
