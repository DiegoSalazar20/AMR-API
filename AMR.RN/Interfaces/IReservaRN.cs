﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMR.DA.Entidades;
using AMR.Dominio;

namespace AMR.RN.Interfaces
{
    public interface IReservaRN
    {
        public Task<(bool, string)> RegistrarReserva(Reserva reserva);
    }
}
