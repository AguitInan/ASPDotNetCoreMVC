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
        public List<Produit> GetAll()
        {
            return _dbContext.Produits.ToList();
        }
        public List<Produit> GetAll(Expression<Func<Produit, bool>> predicate)
        {
            return _dbContext.Produits.Where(predicate).ToList();
        }

        // UPDATE
        public bool Update(Produit produit)
        {
            var produitFromDb = GetById(produit.Id);

            if (produitFromDb == null)
                return false;

            if (produitFromDb.Nom != produit.Nom)
                produitFromDb.Nom = produit.Nom;
            if (produitFromDb.Description != produit.Description)
                produitFromDb.Description = produit.Description;
            if (produitFromDb.Prix != produit.Prix)
                produitFromDb.Prix = produit.Prix;
            if (produitFromDb.Quantite != produit.Quantite)
                produitFromDb.Quantite = produit.Quantite;
            if (produitFromDb.ImageUrl != produit.ImageUrl)
                produitFromDb.ImageUrl = produit.ImageUrl;

            return _dbContext.SaveChanges() > 0;
        }

        // DELETE
        public bool Delete(int id)
        {
            var produit = GetById(id);
            if (produit == null)
                return false;
            _dbContext.Produits.Remove(produit);
            return _dbContext.SaveChanges() > 0;
        }
    }
}
