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

        // READ
        public TodoItem? GetById(int id)
        {
            return _dbContext.TodoItems.Find(id);
        }
        public TodoItem? Get(Expression<Func<TodoItem, bool>> predicate)
        {
            return _dbContext.TodoItems.FirstOrDefault(predicate);
        }





    }
}
