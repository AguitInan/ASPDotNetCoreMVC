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
    }
}
