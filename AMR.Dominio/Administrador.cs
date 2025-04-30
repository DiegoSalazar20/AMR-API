using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMR.Dominio
{
    public class Administrador
    {
        public int IdAdministrador { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set; } 
        public string Contrasena { get; set; } 
        public bool Estado { get; set; }
    }
}
