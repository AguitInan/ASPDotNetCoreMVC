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
        public List<TodoItem> GetAll()
        {
            return _dbContext.TodoItems.ToList();
        }
        public List<TodoItem> GetAll(Expression<Func<TodoItem, bool>> predicate)
        {
            return _dbContext.TodoItems.Where(predicate).ToList();
        }

        // UPDATE
        public bool Update(TodoItem todoItem)
        {
            var todoItemFromDb = GetById(todoItem.Id);

            if (todoItemFromDb == null)
                return false;

            if (todoItemFromDb.Title != todoItem.Title)
                todoItemFromDb.Title = todoItem.Title;
            if (todoItemFromDb.Description != todoItem.Description)
                todoItemFromDb.Description = todoItem.Description;
            if (todoItemFromDb.IsCompleted != todoItem.IsCompleted)
                todoItemFromDb.IsCompleted = todoItem.IsCompleted;

            return _dbContext.SaveChanges() > 0;
        }

        // DELETE
        public bool Delete(int id)
        {
            var todoItem = GetById(id);
            if (todoItem == null)
                return false;
            _dbContext.TodoItems.Remove(todoItem);
            return _dbContext.SaveChanges() > 0;
        }
    }
}
