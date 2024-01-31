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

        public IActionResult CreateRandom()
        {
            var marmoset = new Marmoset
            {
                Name = RandomString("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 10),
                Color = RandomString("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 5)
            };

            _fakeMarmosetDb.Add(marmoset);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _fakeMarmosetDb.Delete(id);
            return RedirectToAction("Index");
        }


        public static string RandomString(string chars, int length)
        {
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}
