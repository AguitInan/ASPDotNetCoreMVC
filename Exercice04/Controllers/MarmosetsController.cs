using Exercice04.Data;
using Exercice04.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exercice04.Controllers
{
    public class MarmosetsController : Controller
    {

        private FakeMarmosetDb _fakeMarmosetDb;

        public MarmosetsController(FakeMarmosetDb fakeMarmosetDb)
        {
            _fakeMarmosetDb = fakeMarmosetDb;
        }

        // Affiche la liste de Marmosets
        public IActionResult Index()
        {

            return View(_fakeMarmosetDb.GetAll());
        }

        // /Marmosets/Details/5
        public IActionResult Details(int id)
        {
            Marmoset? marmoset = _fakeMarmosetDb.GetById(id);

            return View(marmoset);
        }


        public static string RandomString(string chars, int length)
        {
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}
