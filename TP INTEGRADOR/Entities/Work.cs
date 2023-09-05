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

        [Required]
        [Column ("CodService")]
        public int CodService { get; set; }

        [Required]
        [Column ("AmountHours")]
        public int AmountHours { get; set; }

        [Required]
        [Column ("ValuePerHour", TypeName = "DECIMAL(18, 0)")]
        public decimal ValuePerHour { get; set; }

        [Required]
        [Column ("Cost", TypeName = "DECIMAL(18, 0)")]
        public decimal Cost { get; set; }
    }
}
