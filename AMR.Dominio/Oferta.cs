using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AMR.Dominio
{
    public class Oferta
    {
        public int IdOferta {  get; set; }
        public string Nombre_Oferta { get; set; }
        public DateTime Fecha_inicio { get; set; }
        public DateTime Fecha_final { get; set; }
        public int Descuento { get; set; }
        public int IdTipoHabitacion { get; set; }
    }
}
