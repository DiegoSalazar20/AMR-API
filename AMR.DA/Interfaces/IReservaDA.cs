using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMR.DA.Entidades;
using AMR.Dominio;

namespace AMR.DA.Interfaces
{
    public interface IReservaDA
    {
        public Task<(bool, string)> RegistrarReserva(int idhabitacion, string bloqueoToken, string nombre, string apellido, string correo, string tarjeta, DateTime fechaLlegada, DateTime fechaSalida);

        public Task<string> ObtenerTodasLasReservas();

        public Task<bool> EliminarReserva(int idReserva);
    }
}
