using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMR.DA.Entidades
{
    [Table("Temporada")]
    public class TemporadaEntidad
    {
        [Key]
        public int IdTemporada { get; set; }
        [Required]
        public string Nombre_temporada { get; set; }
        [Required]
        public DateTime Fecha_inicio { get; set; }
        [Required]
        public DateTime Fecha_final { get; set; }
        [Required]
        public int Descuento { get; set; }
    }
}
