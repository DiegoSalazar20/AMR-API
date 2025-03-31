﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMR.Dominio;

namespace AMR.DA.Interfaces
{
    public interface ISobreNosotrosDA
    {
        public Task<SobreNosotros> ObtenerInformacion();
        public Task<bool> ActualizarInformacion(SobreNosotros sobreNosotros);
    }
}
