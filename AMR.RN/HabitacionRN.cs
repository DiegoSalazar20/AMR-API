﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMR.DA.Entidades;
using AMR.DA.Interfaces;
using AMR.RN.Interfaces;

namespace AMR.RN
{
    public class HabitacionRN : IHabitacionRN
    {
        private readonly IHabitacionDA _habitacionDA;

        public HabitacionRN(IHabitacionDA habitacionDA)
        {
            _habitacionDA = habitacionDA;
        }
        public async Task<IEnumerable<TipoHabitacionEntidad>> ConsultarDisponibilidad(DateTime fechaInicio, DateTime fechaFin, int idTipoHabitacion)
        {
            return await this._habitacionDA.ConsultarDisponibilidad(fechaInicio,fechaFin,idTipoHabitacion);
        }

    }
}
