using System.Linq.Expressions;
using Tp02.Data;
using Tp02.Models;

namespace Tp02.Repositories
{
    public class ProduitRepository : IRepository<Produit>
    {
        private readonly ApplicationDbContext _dbContext;
        public ProduitRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        // CREATE
        public bool Add(Produit produit)
        {
            var addedObj = _dbContext.Produits.Add(produit);
            _dbContext.SaveChanges();
            return addedObj.Entity.Id > 0;
        }

        // READ
        public Produit? GetById(int id)
        {
            return _dbContext.Produits.Find(id);
        }
        public Produit? Get(Expression<Func<Produit, bool>> predicate)
        {
            return _dbContext.Produits.FirstOrDefault(predicate);
        }

    }
}
