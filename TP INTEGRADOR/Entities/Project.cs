using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_INTEGRADOR.Entities
{
    public class Project
    {
        [Key]
        [Column ("CodProject")]
        public int CodProject { get; set; }

        [Required]
        [Column ("Name", TypeName = "VARCHAR(40)")]
        public string Name { get; set; }

        [Required]
        [Column ("Direction", TypeName = "VARCHAR(30)")]
        public string Direction { get; set; }

        [Required]
        [Column ("State")]
        public int State { get; set; }

        [Column("LeavingDate", TypeName = "DATE")]
        public DateTime? LeavingDate { get; set; }


        //Propiedad de navegacion
        public ICollection<Work> Works { get; set; }
    }
}
