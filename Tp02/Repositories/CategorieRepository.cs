﻿using System.Linq.Expressions;
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

    }
}
