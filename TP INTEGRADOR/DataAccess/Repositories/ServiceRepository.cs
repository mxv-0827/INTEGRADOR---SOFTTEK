using TP_INTEGRADOR.DataAccess.Repositories.Interface;
using TP_INTEGRADOR.Entities;

namespace TP_INTEGRADOR.DataAccess.Repositories
{
    public class ServiceRepository : Repository<Service>, IRepository<Service>
    {
        public ServiceRepository(ApplicationDBContext dbContext) : base(dbContext)
        {

        }
    }
}
