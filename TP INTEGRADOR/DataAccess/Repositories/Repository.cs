﻿using Microsoft.EntityFrameworkCore;
using TP_INTEGRADOR.DataAccess.Repositories.Interface;

namespace TP_INTEGRADOR.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDBContext _dbContext;
        public Repository(ApplicationDBContext dbContext) 
        {
            _dbContext = dbContext;
        }


        public virtual async Task<List<T>> GetAll() => await _dbContext.Set<T>().ToListAsync();
        public virtual async Task<T> GetById(int id) => await _dbContext.Set<T>().FindAsync(id);
    }
}
