using Exercice02.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Demo01.Controllers
{
    public class ContactsController : Controller
    {
        List<Contact> contacts = new List<Contact>
        {
                new Contact { Id = 1, Name = "Iori Yagami", Email = "yagami@mail.com" },
                new Contact { Id = 2, Name = "Kyo Kusanagi", Email = "kusanagi@mail.com" }
        };

        public IActionResult Index()
        {

            //ViewBag.Contacts = contacts;
            //ViewData["Contacts"] = contacts;

            return View(contacts);
        }

        public IActionResult Details(int id)
        {

            var contact = contacts.FirstOrDefault(c => c.Id == id);

            if (contact == null)
            {
                return NotFound();
            }

            //ViewBag.Contact = contact;
            //ViewData["Contact"] = contact;

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
