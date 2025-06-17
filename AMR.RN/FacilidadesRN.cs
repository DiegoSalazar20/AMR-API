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
    public class FacilidadesRN : IFacilidadesRN
    {
        private readonly IFacilidadesDA _facilidadesDA;

        public FacilidadesRN(IFacilidadesDA facilidadesDA)
        {
            _facilidadesDA = facilidadesDA;
        }
        public async Task<bool> ActualizarInformacion(int idFacilidad, string nombre, string imagen, string descripcion)
        {
            return await this._facilidadesDA.ActualizarInformacion(idFacilidad, nombre, imagen, descripcion);
        }

        public async Task<bool> DeshabilitarFacilidad(int idFacilidad)
        {
            return await this._facilidadesDA.DeshabilitarFacilidad(idFacilidad);
        }

        public async Task<bool> HabilitarFacilidad(int idFacilidad)
        {
            return await this._facilidadesDA.HabilitarFacilidad(idFacilidad);
        }

        public async Task<IEnumerable<Facilidades>> ObtenerInformacion()
        {
            return await this._facilidadesDA.ObtenerInformacion();
        }

        public async Task<IEnumerable<Facilidades>> ObtenerInformacionVisibles()
        {
            return await this._facilidadesDA.ObtenerInformacionVisibles();
        }

        public async Task<bool> RegistrarFacilidad(Facilidades facilidad)
        {
            return await this._facilidadesDA.RegistrarFacilidad(facilidad);
        }
    }
}
