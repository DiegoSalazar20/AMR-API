using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMR.DA.Entidades
{
    [Table("Habitacion")]
    public class HabitacionEntidad
    {
        [Key]
        public int IdHabitacion { get; set; } 

        [Required]
        [MaxLength(10)]
        public string NumeroHabitacion { get; set; }

        [Required]
        public int IdTipoHabitacion { get; set; }

        [Required]
        public bool Habilitada { get; set; } 

        [ForeignKey("IdTipoHabitacion")]
        public TipoHabitacionEntidad TipoHabitacion { get; set; }
    }
}
