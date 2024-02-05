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

    }
}
