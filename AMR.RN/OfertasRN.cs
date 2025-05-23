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
    public class OfertasRN : IOfertasRN
    {
        private readonly IOfertasDA _ofertasDA;

        public OfertasRN(IOfertasDA ofertaDA)
        {
            _ofertasDA = ofertaDA;
        }

        public async Task<bool> ActualizarOferta(int idOferta, string nombre_oferta, DateTime fecha_inicio, DateTime fecha_final, int descuento, int idTipoHabitacion)
        {
            return await this._ofertasDA.ActualizarOferta(idOferta, nombre_oferta, fecha_inicio, fecha_final, descuento, idTipoHabitacion);
        }

        public async Task<bool> EliminarOferta(int idOferta)
        {
            return await this._ofertasDA.EliminarOferta(idOferta);
        }

        public async Task<IEnumerable<Oferta>> ObtenerOfertas()
        {
            return await this._ofertasDA.ObtenerOfertas();
        }

        public async Task<bool> RegistrarOferta(Oferta oferta)
        {
            return await this._ofertasDA.RegistrarOferta(oferta);
        }
    }
}
