namespace TP_INTEGRADOR.DataAccess.Repositories.Interface
{
    public interface IRepository<T> where T : class
    {
        public Task<List<T>> GetAll();
    }
}
