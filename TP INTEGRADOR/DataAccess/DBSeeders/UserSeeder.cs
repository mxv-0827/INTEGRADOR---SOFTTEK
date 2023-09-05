using Microsoft.EntityFrameworkCore;
using TP_INTEGRADOR.DataAccess.Interface;
using TP_INTEGRADOR.Entities;

namespace TP_INTEGRADOR.DataAccess.DBSeeders
{
    public class UserSeeder : IEntitySeeder
    {
        public void SeedDB(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(

                new User
                {
                    CodUser = 1,
                    Name = "Maximiliano Viand",
                    DNI = 12345678,
                    Password = "admin1234",
                    UserRole = 1
                }
            );
        }
    }
}
