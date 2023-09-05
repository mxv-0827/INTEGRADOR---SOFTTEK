using Microsoft.EntityFrameworkCore;

namespace TP_INTEGRADOR.DataAccess.Interface
{
    public interface IEntitySeeder
    {
        void SeedDB(ModelBuilder modelBuilder);
    }
}
