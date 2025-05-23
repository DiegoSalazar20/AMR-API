using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMR.Dominio;

namespace AMR.DA.Interfaces
{
    public interface IOfertasDA
    {
        public Task<bool> ActualizarOferta(int idOferta, string nombre_oferta, DateTime fecha_inicio, DateTime fecha_final, int descuento, int idTipoHabitacion);
        public Task<bool> EliminarOferta(int idOferta);
        public Task<IEnumerable<Oferta>> ObtenerOfertas();
        public Task<bool> RegistrarOferta(Oferta oferta);
    }
}
