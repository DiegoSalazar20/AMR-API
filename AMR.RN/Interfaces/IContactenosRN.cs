using AMR.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMR.RN.Interfaces
{
    public interface IContactenosRN
    {
        public Task<Contactenos> ObtenerInformacion();
    }
}
