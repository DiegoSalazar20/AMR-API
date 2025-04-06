using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMR.Dominio
{
    public class ComoLlegar
    {
        public int IdUbicacion { get; set; }

        public string Descripcion { get; set; }

        public decimal Latitud { get; set; }

        public decimal Longitud { get; set; }
    }
}
