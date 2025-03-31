using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMR.DA.Interfaces;
using AMR.Dominio;
using AMR.RN.Interfaces;

namespace AMR.RN
{
    public class HomeRN : IHomeRN
    {

        private readonly IHomeDA _homeDA;

        public HomeRN(IHomeDA homeDA)
        {
            _homeDA = homeDA;
        }
        public async Task<bool> ActualizarInformacion(Home home)
        {
            return await this._homeDA.ActualizarInformacion(home);
        }

        public async Task<Home> ObtenerInformacion()
        {
            return await this._homeDA.ObtenerInformacion();
        }
    }
}
