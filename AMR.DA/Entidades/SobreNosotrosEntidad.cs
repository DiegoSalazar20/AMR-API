using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMR.DA.Entidades
{
    [Table("Sobrenosotros")]
    public class SobreNosotrosEntidad
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Texto { get; set; }
    }
}
