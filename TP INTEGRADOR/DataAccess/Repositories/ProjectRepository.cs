using Microsoft.EntityFrameworkCore;
using System.Linq;
using TP_INTEGRADOR.DataAccess.Repositories.Interface;
using TP_INTEGRADOR.Entities;

namespace TP_INTEGRADOR.DataAccess.Repositories
{
    public class ProjectRepository : Repository<Project>, IRepository<Project>
    {
        public ProjectRepository(ApplicationDBContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<Project>> GetAllStateProjects(int state) => await _dbContext.Set<Project>().Where(x => x.State == state).ToListAsync();

        public override async Task<bool> Update(Project entity, int id)
        {
            var projectToUpdate = await _dbContext.Set<Project>().FirstOrDefaultAsync(x => x.CodProject == id);

            if(projectToUpdate != null)
            {
                projectToUpdate.Name = entity.Name;
                projectToUpdate.Direction = entity.Direction;
                projectToUpdate.State = entity.State;

                return true;
            }

            return false;
        }
    }
}
