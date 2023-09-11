using TP_INTEGRADOR.DataAccess.Repositories.Interface;
using TP_INTEGRADOR.Entities;

namespace TP_INTEGRADOR.DataAccess.Repositories
{
    public class UserRepository : Repository<User>, IRepository<User>
    {
        public UserRepository(ApplicationDBContext dbContext) : base(dbContext)
        {

        }


    }
}
