using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMR.DA.Entidades;
using AMR.DA.Interfaces;
using AMR.Dominio;
using AMR.RN.Interfaces;

namespace AMR.RN
{
    public class ReservaRN : IReservaRN
    {

        private readonly IReservaDA _reservaDA;

        public ReservaRN(IReservaDA reservaDA)
        {
            _reservaDA = reservaDA;
        }

        public async Task<(bool, string)> RegistrarReserva(int idTipoHabitacion, string bloqueoToken, string nombre, string apellido, string correo, string tarjeta, DateTime fechaLlegada, DateTime fechaSalida)
        {
            return await this._reservaDA.RegistrarReserva(idTipoHabitacion, bloqueoToken, nombre, apellido, correo, tarjeta, fechaLlegada, fechaSalida);
        }
    }
}
