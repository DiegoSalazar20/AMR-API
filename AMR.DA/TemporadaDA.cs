using AMR.DA.Contexto;
using AMR.DA.Entidades;
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
    public class TemporadaDA : ITemporadaDA
    {

        private readonly ContextoBD _context;

        public TemporadaDA(ContextoBD context)
        {
            _context = context;
        }


        public async Task<bool> ActualizarTemporada(int idTemporada, string nombre_temporada, DateTime fecha_inicio, DateTime fecha_final, int descuento)
        {
            var temporadaActualizada = await _context.Temporada.FindAsync(idTemporada);

            if (temporadaActualizada == null)
                return false;

            temporadaActualizada.Nombre_temporada = nombre_temporada;
            temporadaActualizada.Fecha_inicio = fecha_inicio;
            temporadaActualizada.Fecha_final = fecha_final;
            temporadaActualizada.Descuento = descuento;

            var otraTemporada = await _context.Temporada
                .FirstOrDefaultAsync(t => t.IdTemporada != idTemporada);

            if (otraTemporada != null)
            {
                otraTemporada.Fecha_inicio = fecha_final.AddDays(1);

                otraTemporada.Fecha_final = fecha_inicio.AddDays(-1);

                if (otraTemporada.Fecha_final < otraTemporada.Fecha_inicio)
                {
                    otraTemporada.Fecha_final = new DateTime(
                        otraTemporada.Fecha_final.Year + 1,
                        otraTemporada.Fecha_final.Month,
                        otraTemporada.Fecha_final.Day);
                }
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarTemporada(int idTemporada)
        {
            var temporada = await _context.Temporada.FindAsync(idTemporada);
            if (temporada == null)
                return false;

            _context.Temporada.Remove(temporada);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Temporada>> ObtenerTemporadas()
        {
            return await _context.Temporada
                .Select(t => new Temporada
                {
                    IdTemporada = t.IdTemporada,
                    Nombre_temporada = t.Nombre_temporada,
                    Fecha_inicio = t.Fecha_inicio,
                    Fecha_final = t.Fecha_final,
                    Descuento = t.Descuento
                }).ToListAsync();
        }

        public async Task<bool> RegistrarTemporada(Temporada temporada)
        {
            try
            {
                var nuevaTemporada = new TemporadaEntidad
                {
                    Nombre_temporada = temporada.Nombre_temporada,
                    Fecha_inicio = temporada.Fecha_inicio,
                    Fecha_final = temporada.Fecha_final,
                    Descuento = temporada.Descuento
                };

                _context.Temporada.Add(nuevaTemporada);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
