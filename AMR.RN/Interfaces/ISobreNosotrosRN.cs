﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMR.Dominio;

namespace AMR.RN.Interfaces
{
    public interface ISobreNosotrosRN
    {
        public Task<SobreNosotros> ObtenerInformacion();
        public Task<bool> ActualizarInformacion(SobreNosotros sobreNosotros);
    }
}
