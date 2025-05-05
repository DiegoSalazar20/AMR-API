using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMR.DA.Entidades
{
    [Table("HabitacionesPorReservar")]
    public class HabitacionesPorReservarEntidad
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int IdHabitacion { get; set; }
        [ForeignKey("IdHabitacion")]
        public HabitacionEntidad Habitacion { get; set; }

        [Required, MaxLength(50)]
        public string Token { get; set; }

        [Required]
        public DateTime Expiracion { get; set; }
    }
}
