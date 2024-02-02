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

        // Route => /TodoItem
        public IActionResult Index()
        {
            return View(_todoItemRepository.GetAll());
        }

        // Route =>  TodoItemController/Details/5
        public IActionResult Details(int id)
        {
            return View(_todoItemRepository.GetById(id));
        }

        // Route => TodoItemController/CreateRandom
        //public IActionResult CreateRandom()
        //{
        //    TodoItem? an = new TodoItem()
        //    {
        //        FirstName = RandomString("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 5),
        //        Age = new Random().Next(40),
        //        Species = RandomString("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 5).ToLower(),
        //    };

        //    //_fakeAnimalDb.Add(an);

        //    //_dbContext.Animals.Add(an);
        //    //_dbContext.SaveChanges();

        //    _todoItemRepository.Add(an);

        //    return RedirectToAction(nameof(Index));
        //}

        public IActionResult Form(int id)
        {
            if (id == 0) // pas d'id => ADD
                return View();

            // Sinon UPDATE
            var todoItem = _todoItemRepository.GetById(id);

            return View(todoItem);
        }

        public IActionResult Create()
        {
            return View();
        }







    }
}
