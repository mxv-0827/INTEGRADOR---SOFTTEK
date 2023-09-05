using Microsoft.EntityFrameworkCore;
using TP_INTEGRADOR.DataAccess.Interface;
using TP_INTEGRADOR.Entities;

namespace TP_INTEGRADOR.DataAccess.DBSeeders
{
    public class WorkSeeder : IEntitySeeder
    {
        public void SeedDB(ModelBuilder modelBuilder)
        {
            Work work = new Work
            {
                CodWork = 1,
                Date = DateTime.Now,
                CodProject = 1,
                CodService = 1,
                AmountHours = 35,
                ValuePerHour = 12,
            };

            work.Cost = work.ValuePerHour * work.AmountHours;

            modelBuilder.Entity<Work>().HasData(work);
        }
    }
}
