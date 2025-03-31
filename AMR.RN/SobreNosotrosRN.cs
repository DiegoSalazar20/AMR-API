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
    public class SobreNosotrosRN : ISobreNosotrosRN
    {

        private readonly ISobreNosotrosDA _sobrenosotrosDA;

        public SobreNosotrosRN(ISobreNosotrosDA sobrenosotrosDA)
        {
            _sobrenosotrosDA = sobrenosotrosDA;
        }
        public async Task<bool> ActualizarInformacion(SobreNosotros sobreNosotros)
        {
            return await this._sobrenosotrosDA.ActualizarInformacion(sobreNosotros);
        }

        public async Task<SobreNosotros> ObtenerInformacion()
        {
            return await this._sobrenosotrosDA.ObtenerInformacion();
        }
    }
}
