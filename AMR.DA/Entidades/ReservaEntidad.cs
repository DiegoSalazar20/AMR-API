using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMR.DA.Entidades
{
    [Table("Reserva")]
    public class ReservaEntidad
    {
        [Key]
        public int IdReserva { get; set; } 

        [Required]
        [MaxLength(20)]
        public string CodigoReserva { get; set; } 

        [Required]
        [MaxLength(20)]
        public string NumeroTransaccion { get; set; } 

        [Required]
        public int IdHabitacion { get; set; }

        [ForeignKey("IdHabitacion")]
        public HabitacionEntidad Habitacion { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(100)]
        public string Apellidos { get; set; }

        [Required]
        [MaxLength(150)]
        public string Email { get; set; }

        [Required]
        [MaxLength(4)]
        public string Tarjeta { get; set; } 

        [Required]
        public DateTime FechaLlegada { get; set; } 

        [Required]
        public DateTime FechaSalida { get; set; } 

    }
}
