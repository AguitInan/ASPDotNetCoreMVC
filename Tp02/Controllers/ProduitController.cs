using Microsoft.AspNetCore.Mvc;
using Tp02.Models;
using Tp02.Repositories;

namespace Tp02.Controllers
{
    public class ProduitController : Controller
    {
        private readonly IRepository<Produit> _repository;

        public ProduitController(IRepository<Produit> repositoryProduit)
        {
            _repository = repositoryProduit;
        }

        public IActionResult Index()
        {
            return View(_repository.GetAll());
        }

        //public IActionResult Change(int id)
        //{
        //    var produit = _repository.GetById(id);
        //    produit.Finished = !produit.Finished; // toggle
        //    _repository.Update(produit);
        //    return RedirectToAction("Index");
        //}

        public IActionResult Add()
        {
            return View();
        }

        //public IActionResult Submit(Produit produit)
        //{
        //    _repository.Create(produit);
        //    return RedirectToAction("Index");
        //}
    }
}
