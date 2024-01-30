using Exercice01.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Demo01.Controllers
{
    public class ContactsController : Controller
    {

        public string Index()
        {
            return "Je suis la page pour afficher contacts...";
        }

        public string Details(int id)
        {
            return $"Je suis la page pour afficher le contact n°{id} en détail...";
        }

        public string Add()
        {
            return "Je suis la page pour ajouter un contact...";
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
