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

        public IActionResult SubmitTodoItem(TodoItem todoItem)
        {
            // 2 cas de submit possible:
            // -ajout d'un contact => Id == 0
            // -modification d'un contact => Id != 0

            if (todoItem.Id == 0)
                _todoItemRepository.Add(todoItem);
            else
                _todoItemRepository.Update(todoItem);

            return RedirectToAction(nameof(Index));
        }

        // Route => TodoItemController/Delete/5
        public IActionResult Delete(int id)
        {
            _todoItemRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        [NonAction] // ce n'est plus une action => un méthode classique sans route 
        public static string RandomString(string chars, int length)
        {
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}
