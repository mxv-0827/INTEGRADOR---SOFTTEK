using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_INTEGRADOR.Entities
{
    public class Role
    {
        [Key]
        [Column("CodRole")]
        public int CodRole { get; set; }

        [Required]
        [Column("Description", TypeName = "VARCHAR(60)")]
        public string Description { get; set; }

        [Column("LeavingDate", TypeName = "DATE")]
        public DateTime? LeavingDate { get; set; }


        public ICollection<User> Users { get; set; } //Propiedad de navegacion
    }
}
