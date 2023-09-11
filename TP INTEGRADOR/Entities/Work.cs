using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_INTEGRADOR.Entities
{
    public class Work
    {
        [Key]
        [Column ("CodWork")]
        public int CodWork { get; set; }

        [Required]
        [Column ("Date", TypeName = "DATE")]
        public DateTime Date { get; set; }

        [Required]
        [Column ("CodProject")]
        public int CodProject { get; set; }
        [ForeignKey ("CodProject")] //Le asignamos nombre de identifacion a la FK.
        public Project Project { get; set; } //Propiedad de navegacion.

        [Required]
        [Column ("CodService")]
        public int CodService { get; set; }
        [ForeignKey ("CodService")] //Le asignamos nombre de identifacion a la FK.
        public Service Service { get; set; } //Propiedad de navegacion.

        [Required]
        [Column ("AmountHours")]
        public int AmountHours { get; set; }

        [Required]
        [Column ("ValuePerHour", TypeName = "DECIMAL(18, 0)")]
        public decimal ValuePerHour { get; set; }

        [Required]
        [Column ("Cost", TypeName = "DECIMAL(18, 0)")]
        public decimal Cost { get; set; }

        [Column ("LeavingDate", TypeName = "DATE")]
        public DateTime? LeavingDate { get; set; }
    }
}
