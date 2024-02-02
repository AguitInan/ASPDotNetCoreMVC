using Microsoft.AspNetCore.Mvc;
using Tp01.Models;
using Tp01.Data;
using Tp01.Repositories;


namespace Tp01.Controllers
{
    public class TodoItemController : Controller
    {
        private readonly IRepository<TodoItem> _todoItemRepository;

        public TodoItemController(IRepository<TodoItem> todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }













    }
}
