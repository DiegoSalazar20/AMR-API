using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMR.Dominio;

namespace AMR.RN.Interfaces
{
    public interface IFacilidadesRN
    {
        public Task<IEnumerable<Facilidades>> ObtenerInformacion();
        public Task<IEnumerable<Facilidades>> ObtenerInformacionVisibles();
        public Task<bool> ActualizarInformacion(int idFacilidad, string nombre, string imagen, string descripcion);

        public Task<bool> HabilitarFacilidad(int idFacilidad);

        public Task<bool> DeshabilitarFacilidad(int idFacilidad);

        public Task<bool> RegistrarFacilidad(Facilidades facilidad);
    }
}
