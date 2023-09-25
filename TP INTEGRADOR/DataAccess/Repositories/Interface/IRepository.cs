namespace TP_INTEGRADOR.DataAccess.Repositories.Interface
{
    public interface IRepository<T> where T : class
    {
        public Task<List<T>> GetAll();
        public Task<T> GetById(int id);

        public Task<bool>Insert(T entity);
        public Task<bool> Update(T entity, int id);
        public Task<bool> Delete(int id); //Solo de nombre xq no elimina el registro, solo lo desactiva => BORRADO LOGICO / SOFTDELETE.
    }
}
