using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using TP_INTEGRADOR.DataAccess.Repositories.Interface;
using TP_INTEGRADOR.Entities;

namespace TP_INTEGRADOR.DataAccess.Repositories
{
    public class ServiceRepository : Repository<Service>, IRepository<Service>
    {
        public ServiceRepository(ApplicationDBContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<Service>> GetAllActiveServices() => await _dbContext.Set<Service>().Where(x => x.State == true).ToListAsync();

        public override async Task<bool> Update(Service entity, int id)
        {
            var serviceToUpdate = await _dbContext.Set<Service>().FirstOrDefaultAsync(x => x.CodService == id);

            if (serviceToUpdate != null)
            {
                serviceToUpdate.Description = entity.Description;
                serviceToUpdate.State = entity.State;
                serviceToUpdate.HourValue = entity.HourValue;
                serviceToUpdate.LeavingDate = entity.LeavingDate;

                return true;
            }

            return false;
        }
    }
}
