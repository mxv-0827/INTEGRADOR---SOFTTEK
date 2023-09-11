using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_INTEGRADOR.Entities
{
    public class Service
    {
        [Key]
        [Column ("CodService")]
        public int CodService { get; set; }

        [Required]
        [Column ("Description", TypeName = "VARCHAR(150)")]
        public string Description { get; set; }

        [Required]
        [Column ("State")]
        public bool State { get; set; }

        [Required]
        [Column ("HourValue", TypeName = "DECIMAL(18, 0)")]
        public decimal HourValue { get; set; }

        [Column("LeavingDate", TypeName = "DATE")]
        public DateTime? LeavingDate { get; set; }


        //Propiedad de navegacion
        public ICollection<Work> Works { get; set; }


    }
}
