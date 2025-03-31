using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMR.DA.Entidades
{
    [Table("Facilidades")]
    public class FacilidadEntidad
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        public string Imagen { get; set; }

        [Required]
        public string Descripcion { get; set; }
        [Required]
        public bool Estado { get; set; }
    }
}
