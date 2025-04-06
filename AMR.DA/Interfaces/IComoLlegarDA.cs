using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMR.Dominio;

namespace AMR.DA.Interfaces
{
    public interface IComoLlegarDA
    {
        public Task<ComoLlegar> ObtenerInformacion();
    }
}
