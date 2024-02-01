using Exercice04.Data;
using Exercice04.Models;
using Microsoft.AspNetCore.Mvc;
using static Exercice04.Models.Marmoset;
using System;

namespace Exercice04.Controllers
{
    public class MarmosetsController : Controller
    {

        //private FakeMarmosetDb _fakeMarmosetDb;

        private readonly MarmosetDbContext _context;

        public MarmosetsController(MarmosetDbContext context)
        {
            _context = context;
        }

        //public MarmosetsController(FakeMarmosetDb fakeMarmosetDb)
        //{
        //    _fakeMarmosetDb = fakeMarmosetDb;
        //}

        // Affiche la liste de Marmosets
        public IActionResult Index()
        {
            return View(_context.Marmosets.ToList());
        }

        // /Marmosets/Details/5
        public IActionResult Details(int id)
        {
            return View(_context.Marmosets.FirstOrDefault(a => a.Id == id));
        }

        public IActionResult CreateRandom()
        {
            var marmoset = new Marmoset
            {
                Name = RandomString("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 6),
                Color = RandomColor()
            };

            //_context.Add(marmoset);
            _context.Marmosets.Add(marmoset);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var marmoset = _context.Marmosets.FirstOrDefault(a => a.Id == id);
            _context.Marmosets.Remove(marmoset);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public static string RandomString(string chars, int length)
        {
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static MarmosetColor RandomColor()
        {
            Random random = new Random();
            var colors = Enum.GetValues(typeof(MarmosetColor));
            MarmosetColor randomColor = (MarmosetColor)colors.GetValue(random.Next(colors.Length));

            return randomColor;
        }

    }
}
