using AMR.DA.Interfaces;
using AMR.Dominio;
using AMR.RN.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMR.RN
{
    public class AdministradorRN : IAdministradorRN
    {
        private readonly IAdministradorDA _administradorDA;

        public AdministradorRN(IAdministradorDA administradorDA)
        {
            _administradorDA = administradorDA;
        }
        public async Task<Administrador> InicioSesion(string nombreUsuario, string contrasena)
        {
            return await this._administradorDA.InicioSesion(nombreUsuario, contrasena);
        }
    }
}
