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

        // CREATE
        public bool Add(TodoItem todoItem)
        {
            var addedObj = _dbContext.TodoItems.Add(todoItem);
            _dbContext.SaveChanges();
            return addedObj.Entity.Id > 0;
        }







    }
}
