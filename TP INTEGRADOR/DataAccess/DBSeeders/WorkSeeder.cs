using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TP_INTEGRADOR.Entities;

namespace TP_INTEGRADOR.DataAccess.DBSeeders
{
    public class WorkSeeder : IEntityTypeConfiguration<Work>
    {
        public void Configure(EntityTypeBuilder<Work> builder)
        {
            var works = new List<Work>
            {
                new Work { CodWork = 1, Date = DateTime.Now, CodProject = 4, CodService = 4, AmountHours = 1, ValuePerHour = 5 },
                new Work { CodWork = 2, Date = DateTime.Now, CodProject = 3, CodService = 3, AmountHours = 2, ValuePerHour = 6 },
                new Work { CodWork = 3, Date = DateTime.Now, CodProject = 2, CodService = 2, AmountHours = 3, ValuePerHour = 7 },
                new Work { CodWork = 4, Date = DateTime.Now, CodProject = 1, CodService = 1, AmountHours = 4, ValuePerHour = 8 },
            };

            // Se calcula la propiedad 'cost' para cada objeto Work.
            foreach (var work in works)
            {
                work.Cost = work.AmountHours * work.ValuePerHour;
            }

            builder.HasData(works);
        }
    }
}
