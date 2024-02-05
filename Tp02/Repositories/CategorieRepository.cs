using System.Linq.Expressions;
using Tp02.Data;
using Tp02.Models;

namespace Tp02.Repositories
{
    public class CategorieRepository : IRepository<Categorie>
    {
        private readonly ApplicationDbContext _dbContext;
        public CategorieRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        // CREATE
        public bool Add(Categorie categorie)
        {
            var addedObj = _dbContext.Categories.Add(categorie);
            _dbContext.SaveChanges();
            return addedObj.Entity.Id > 0;
        }

        // READ
        public Categorie? GetById(int id)
        {
            return _dbContext.Categories.Find(id);
        }
        public Categorie? Get(Expression<Func<Categorie, bool>> predicate)
        {
            return _dbContext.Categories.FirstOrDefault(predicate);
        }
        public List<Categorie> GetAll()
        {
            return _dbContext.Categories.ToList();
        }
        public List<Categorie> GetAll(Expression<Func<Categorie, bool>> predicate)
        {
            return _dbContext.Categories.Where(predicate).ToList();
        }

        // UPDATE
        public bool Update(Categorie categorie)
        {
            var categorieFromDb = GetById(categorie.Id);

            if (categorieFromDb == null)
                return false;

            if (categorieFromDb.Nom != categorie.Nom)
                categorieFromDb.Nom = categorie.Nom;

            return _dbContext.SaveChanges() > 0;
        }

    }
}
