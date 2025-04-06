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
    public class ComoLlegarRN : IComoLlegarRN
    {
        private readonly IComoLlegarDA _comoLlegarDA;

        public ComoLlegarRN(IComoLlegarDA comoLlegarDA)
        {
            _comoLlegarDA = comoLlegarDA;
        }

        public async Task<ComoLlegar> ObtenerInformacion()
        {
            return await this._comoLlegarDA.ObtenerInformacion();
        }
    }
}
