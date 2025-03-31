using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMR.Dominio
{
    public class Habitacion
    {
        public int IdHabitacion { get; set; }               
        public string NumeroHabitacion { get; set; } 
        public int IdTipoHabitacion { get; set; } 
        public bool Habilitada { get; set; }
    }
}
