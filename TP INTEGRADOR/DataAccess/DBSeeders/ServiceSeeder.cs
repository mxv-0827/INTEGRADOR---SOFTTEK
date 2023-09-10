using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TP_INTEGRADOR.DataAccess.Interface;
using TP_INTEGRADOR.Entities;

namespace TP_INTEGRADOR.DataAccess.DBSeeders
{
    public class ServiceSeeder : IEntityTypeConfiguration<Service>
    {

        //public void SeedDB(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Service>().HasData(

        //        new Service
        //        {
        //            CodService = 1,
        //            Description = "Un servicio que hace bla bla bla",
        //            State = true,
        //            HourValue = 123
        //        }
        //    );
        //}
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasData(
                new Service { CodService = 1, Description = "aaa", State = true, HourValue = 80},
                new Service { CodService = 2, Description = "bbb", State = false, HourValue = 12},
                new Service { CodService = 3, Description = "ccc", State = true, HourValue = 20},
                new Service { CodService = 4, Description = "ddd", State = false, HourValue = 65}
                );
        }
    }
}
