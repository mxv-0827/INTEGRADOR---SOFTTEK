using Microsoft.EntityFrameworkCore;
using TP_INTEGRADOR.DataAccess.Interface;
using TP_INTEGRADOR.Entities;

namespace TP_INTEGRADOR.DataAccess.DBSeeders
{
    public class ProjectSeeder : IEntitySeeder
    {
        public void SeedDB(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasData(

                new Project
                {
                    CodProject = 1,
                    Name = "Project number 1",
                    Direction = "Calle xD 1234",
                    State = false
                }
            );
        }
    }
}
