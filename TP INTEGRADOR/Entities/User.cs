using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_INTEGRADOR.Entities
{
    public class User
    {
        [Key]
        [Column ("CodUser")]
        public int CodUser { get; set; }

        [Required]
        [Column ("Name", TypeName = "VARCHAR(60)")]
        public string Name { get; set; }

        [Required]
        [MaxLength(8)]
        [Column ("DNI")]
        public int DNI { get; set; }

        [Required]
        [Column ("Password", TypeName = "VARCHAR(15)")]
        public string Password { get; set; }

        [Required]
        [Column ("UserRole")]
        public int UserRole { get; set; }

        [Column ("LeavingDate", TypeName = "DATE")]
        public DateTime? LeavingDate { get; set; }
    }
}
