using AMR.DA.Interfaces;
using AMR.Dominio;
using AMR.RN.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMR.RN
{
    public class ContactenosRN : IContactenosRN
    {
        private readonly IContactenosDA _contactenosDA;

        public ContactenosRN(IContactenosDA contactenosDA)
        {
            _contactenosDA = contactenosDA;
        }

        public async Task<Contactenos> ObtenerInformacion()
        {
            return await this._contactenosDA.ObtenerInformacion();
        }
    }
}
