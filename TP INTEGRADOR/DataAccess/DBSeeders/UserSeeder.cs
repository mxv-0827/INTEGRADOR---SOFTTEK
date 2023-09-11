using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TP_INTEGRADOR.Entities;

namespace TP_INTEGRADOR.DataAccess.DBSeeders
{
    public class UserSeeder : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User { CodUser = 1, Name = "Maxi Viand", DNI = 12345678, Password = "admin1234", UserRole = 1},
                new User { CodUser = 2, Name = "Cris Viand", DNI = 13245678, Password = "admin4321", UserRole = 2},
                new User { CodUser = 3, Name = "Gerardo Viand", DNI = 87654321, Password = "admin2468", UserRole = 1},
                new User { CodUser = 4, Name = "Adriana Neporadnyj", DNI = 67891234, Password = "admin1357", UserRole = 2}
                );
        }
    }
}
