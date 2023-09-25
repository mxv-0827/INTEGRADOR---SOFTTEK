using TP_INTEGRADOR.DataAccess.Repositories.Interface;
using TP_INTEGRADOR.Entities;

namespace TP_INTEGRADOR.DataAccess.Repositories
{
    public class RoleRepository : Repository<Role>, IRepository<Role>
    {
        public RoleRepository(ApplicationDBContext dbContext) : base(dbContext)
        {

        }
    }
}
