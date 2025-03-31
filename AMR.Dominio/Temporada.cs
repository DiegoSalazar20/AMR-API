using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMR.Dominio
{
    public class Temporada
    {
        public int IdTemporada { get; set; }
        public string Nombre_temporada { get; set; }
        public DateTime Fecha_inicio { get; set; }
        public DateTime Fecha_final {  get; set; }
        public int Descuento { get; set; }
    }
}
