using AMR.DA.Contexto;
using AMR.DA.Interfaces;
using AMR.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMR.DA
{
    public class ContactenosDA : IContactenosDA
    {
        private readonly ContextoBD _context;

        public ContactenosDA(ContextoBD context)
        {
            _context = context;
        }

        public async Task<Contactenos> ObtenerInformacion()
        {
            try
            {
                var contactoEntidad = await _context.Contactenos.FirstOrDefaultAsync();

                if (contactoEntidad == null)
                    return null;

                Contactenos datos = new Contactenos
                {
                    Id = contactoEntidad.Id,
                    Telefono = contactoEntidad.Telefono,
                    ApdoPostal = contactoEntidad.ApdoPostal,
                    Correo = contactoEntidad.Correo
                };

                return datos;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
