using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMR.DA.Entidades
{
    [Table("Ofertas")]
    public class OfertaEntidad
    {
        [Key]
        public int IdOferta { get; set; }
        [Required]
        public string Nombre_Oferta { get; set; }
        [Required]
        public DateTime Fecha_inicio { get; set; }
        [Required]
        public DateTime Fecha_final { get; set; }
        [Required]
        public int Descuento { get; set; }
        [ForeignKey("IdHabitacion")]
        public int IdTipoHabitacion { get; set; }
    }
}
