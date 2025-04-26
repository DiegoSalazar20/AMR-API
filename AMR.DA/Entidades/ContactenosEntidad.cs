using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMR.DA.Entidades
{
    [Table("contactenos")]
    public class ContactenosEntidad
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public string ApdoPostal { get; set; }
        [Required]
        public string Correo { get; set; }
    }
}
