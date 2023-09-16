using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TP_INTEGRADOR.Entities;
using TP_INTEGRADOR.Helpers;

namespace TP_INTEGRADOR.DataAccess.DBSeeders
{
    public class UserSeeder : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User { CodUser = 1, Name = "Maxi Viand", DNI = 12345678, Password = PasswordEncrypter_Helper.EncryptPassword("admin1234", 12345678), UserRole = 1},
                new User { CodUser = 2, Name = "Cris Viand", DNI = 13245678, Password = PasswordEncrypter_Helper.EncryptPassword("admin4321", 13245678), UserRole = 2},
                new User { CodUser = 3, Name = "Gerardo Viand", DNI = 87654321, Password = PasswordEncrypter_Helper.EncryptPassword("admin2468", 87654321), UserRole = 1},
                new User { CodUser = 4, Name = "Adriana Neporadnyj", DNI = 67891234, Password = PasswordEncrypter_Helper.EncryptPassword("admin1357", 67891234), UserRole = 2}
                );
        }
    }
}
