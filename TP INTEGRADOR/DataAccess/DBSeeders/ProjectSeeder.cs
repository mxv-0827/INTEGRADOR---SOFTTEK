using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TP_INTEGRADOR.DataAccess.Interface;
using TP_INTEGRADOR.Entities;

namespace TP_INTEGRADOR.DataAccess.DBSeeders
{
    public class ProjectSeeder : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasData(
                new Project { CodProject = 1, Name = "Project number 1", Direction = "Calle xD 1234", State = 1},
                new Project { CodProject = 2, Name = "Project number 2", Direction = "Calle xD 5678", State = 2},
                new Project { CodProject = 3, Name = "Project number 3", Direction = "Calle xD 9102", State = 3},
                new Project { CodProject = 4, Name = "Project number 4", Direction = "Calle xD 3456", State = 1}
                );
        }

        //public void SeedDB(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Project>().HasData(

        //        new Project
        //        {
        //            CodProject = 1,
        //            Name = "Project number 1",
        //            Direction = "Calle xD 1234",
        //            State = false
        //        }
        //    );
        //}
    }
}
