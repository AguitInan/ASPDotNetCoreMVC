using Exercice02.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Demo01.Controllers
{
    public class ContactsController : Controller
    {

        public IActionResult Index()
        {
            var contacts = new List<Contact>
            {
                new Contact { Id = 1, Name = "Iori Yagami", Email = "yagami@mail.com" },
                new Contact { Id = 2, Name = "Kyo Kusanagi", Email = "kusanagi@mail.com" }
            };

            ViewBag.Contacts = contacts;

            ViewData["Contacts"] = contacts;

            return View(contacts);
        }

        public IActionResult Details(int id)
        {
            var contact = new Contact { Id = id, Name = "Iori Yagami", Email = "yagami@mail.com" };

            ViewBag.Contact = contact;

            ViewData["Contact"] = contact;

            return View(contact);
        }

        public IActionResult Add()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
