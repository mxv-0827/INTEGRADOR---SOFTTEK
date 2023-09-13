using Microsoft.EntityFrameworkCore;
using TP_INTEGRADOR.DataAccess.Repositories.Interface;
using TP_INTEGRADOR.Entities;

namespace TP_INTEGRADOR.DataAccess.Repositories
{
    public class WorkRepository : Repository<Work>, IRepository<Work>
    {
        public WorkRepository(ApplicationDBContext dbContext) : base(dbContext)
        {

        }

        public override async Task<bool> Update(Work entity, int id)
        {
            var workToUpdate = await _dbContext.Set<Work>().FirstOrDefaultAsync(x => x.CodWork == id);

            if (workToUpdate != null)
            {
                workToUpdate.Date = entity.Date;
                workToUpdate.CodProject = entity.CodProject;
                workToUpdate.CodService = entity.CodService;
                workToUpdate.AmountHours= entity.AmountHours;
                workToUpdate.ValuePerHour = entity.ValuePerHour;

                return true;
            }

            return false;
        }
    }
}
