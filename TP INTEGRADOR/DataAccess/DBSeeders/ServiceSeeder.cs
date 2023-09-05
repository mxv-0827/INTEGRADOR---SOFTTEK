using Microsoft.EntityFrameworkCore;
using TP_INTEGRADOR.DataAccess.Interface;
using TP_INTEGRADOR.Entities;

namespace TP_INTEGRADOR.DataAccess.DBSeeders
{
    public class ServiceSeeder : IEntitySeeder
    {
        public void SeedDB(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>().HasData(

                new Service
                {
                    CodService = 1,
                    Description = "Un servicio que hace bla bla bla",
                    State = true,
                    HourValue = 123
                }
            );
        }
    }
}
