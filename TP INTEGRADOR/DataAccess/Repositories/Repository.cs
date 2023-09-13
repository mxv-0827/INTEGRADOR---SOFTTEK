using Microsoft.EntityFrameworkCore;
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

        public virtual async Task<bool>Insert(T entity)
        {
            var entityAdded = await _dbContext.Set<T>().AddAsync(entity);
            return entityAdded != null;
        }

        //Como es implementado, no arroja error. Cada entidad actualiza cosas distintas.
        public virtual Task<bool> Update(T entity, int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id) //Todas las entidades comparten la misma propiedad "LEAVINGDATE". Al 'borrar' el registro, el campo se actualiza a la fecha en la que se borro.
        {
            var entity = await GetById(id);

            if (entity != null)
            {
                var leavingDateProperty = typeof(T).GetProperty("LeavingDate");

                leavingDateProperty.SetValue(entity, DateTime.Now);
                return true;
            }

            return false;
        }
    }
}
