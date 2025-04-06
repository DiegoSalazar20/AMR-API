using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMR.DA.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AMR.DA.Contexto
{
    public class ContextoBD : DbContext
    {
        public ContextoBD(DbContextOptions<ContextoBD> options) : base(options)
        {
        }
        public DbSet<HomeEntidad> Home { get; set; }
        public DbSet<FacilidadEntidad> Facilidad { get; set; }
        public DbSet<PublicidadEntidad> Publicidad { get; set; }
        public DbSet<SobreNosotrosEntidad> SobreNosotros { get; set; }
        public DbSet<TipoHabitacionEntidad> TipoHabitacion { get; set; }
        public DbSet<HabitacionEntidad> Habitacion { get; set; }
        public DbSet<ReservaEntidad> Reserva { get; set; }
        public DbSet<TemporadaEntidad> Temporada { get; set; }
        public DbSet<OfertaEntidad> Ofertas { get; set; }
    }
}
