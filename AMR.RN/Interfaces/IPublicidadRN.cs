using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMR.Dominio;

namespace AMR.RN.Interfaces
{
    public interface IPublicidadRN
    {
        public Task<IEnumerable<Publicidad>> ObtenerPublicidadVisible();
        public Task<IEnumerable<Publicidad>> ObtenerTodasLasPublicidades();

        public Task<bool> RegistrarPublicidad(Publicidad publicidad);

        public Task<bool> ActualizarInformacion(int idPublicidad, string nombre, string descripcion, string urlDestino, string urlImagen);

        public Task<bool> HabilitarPublicidad(int idPublicidad);

        public Task<bool> DeshabilitarPublicidad(int idPublicidad);
    }
}
