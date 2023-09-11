using TP_INTEGRADOR.DataAccess.Repositories.Interface;
using TP_INTEGRADOR.Entities;

namespace TP_INTEGRADOR.DataAccess.Repositories
{
    public class WorkRepository : Repository<Work>, IRepository<Work>
    {
        public WorkRepository(ApplicationDBContext dbContext) : base(dbContext)
        {

        }
    }
}
