using TP_INTEGRADOR.DataAccess.Repositories.Interface;
using TP_INTEGRADOR.Entities;

namespace TP_INTEGRADOR.DataAccess.Repositories
{
    public class ProjectRepository : Repository<Project>, IRepository<Project>
    {
        public ProjectRepository(ApplicationDBContext dbContext) : base(dbContext)
        {

        }


    }
}
