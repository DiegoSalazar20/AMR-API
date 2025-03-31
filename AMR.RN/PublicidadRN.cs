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
    public class PublicidadRN : IPublicidadRN
    {

        private readonly IPublicidadDA _publicidadDA;

        public PublicidadRN(IPublicidadDA publicidadDA)
        {
            _publicidadDA = publicidadDA;
        }

        public async Task<bool> ActualizarInformacion(int idPublicidad, string nombre, string descripcion, string urlDestino, string urlImagen)
        {
            return await this._publicidadDA.ActualizarInformacion(idPublicidad, nombre, descripcion, urlDestino, urlImagen);
        }

        public async Task<bool> DeshabilitarPublicidad(int idPublicidad)
        {
            return await this._publicidadDA.DeshabilitarPublicidad(idPublicidad);
        }

        public async Task<bool> HabilitarPublicidad(int idPublicidad)
        {
            return await this._publicidadDA.HabilitarPublicidad(idPublicidad);
        }

        public async Task<IEnumerable<Publicidad>> ObtenerPublicidadVisible()
        {
            return await this._publicidadDA.ObtenerPublicidadVisible();
        }

        public async Task<IEnumerable<Publicidad>> ObtenerTodasLasPublicidades()
        {
            return await this._publicidadDA.ObtenerTodasLasPublicidades();
        }

        public async Task<bool> RegistrarPublicidad(Publicidad publicidad)
        {
            return await this._publicidadDA.RegistrarPublicidad(publicidad);
        }
    }
}
