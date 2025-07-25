﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AMR.DA.Contexto;
using AMR.DA.Entidades;
using AMR.DA.Interfaces;
using AMR.Dominio;
using Microsoft.EntityFrameworkCore;

namespace AMR.DA
{
    public class TipoHabitacionDA : ITipoHabitacionDA
    {
        private readonly ContextoBD _context;

        public TipoHabitacionDA(ContextoBD context)
        {
            _context = context;
        }

        public async Task<bool> ActualizarDatosHabitacion(TipoHabitacion tipoHabitacion)
        {
            var habitacionExistente = await _context.TipoHabitacion.FindAsync(tipoHabitacion.IdTipoHabitacion);

            if (habitacionExistente == null)
                return false;

            habitacionExistente.Descripcion = tipoHabitacion.Descripcion;
            habitacionExistente.Precio=tipoHabitacion.Precio;
            habitacionExistente.Nombre = tipoHabitacion.Nombre;
            habitacionExistente.Imagen=tipoHabitacion.Imagen;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<TipoHabitacion>> ObtenerDatosTiposHabitaciones()
        {
            var tiposhabitaciones = await _context.TipoHabitacion.ToListAsync();

            return tiposhabitaciones.Select(f => new TipoHabitacion
            {
                IdTipoHabitacion = f.IdTipoHabitacion,
                Nombre = f.Nombre,
                Descripcion = f.Descripcion,
                Precio = f.Precio,
                Imagen = f.Imagen
            });

        }

        public async Task<IEnumerable<TipoHabitacion>> ObtenerTarifas()
        {
            var tipoHabitacionesEntidad = await _context.TipoHabitacion.ToListAsync();
            var ofertasEntidad = await _context.Ofertas.ToListAsync();
            var temporadasEntidad = await _context.Temporada.ToListAsync();
            DateTime fechaActual = DateTime.Today;

            foreach (var tipoHabitacionEntidad in tipoHabitacionesEntidad)
            {
                decimal descuentoTemporada = ObtenerDescuentoTemporada(fechaActual, temporadasEntidad);
                tipoHabitacionEntidad.Precio += tipoHabitacionEntidad.Precio * descuentoTemporada;

                foreach (var ofertaEntidad in ofertasEntidad)
                {
                    if (ofertaEntidad.IdTipoHabitacion == tipoHabitacionEntidad.IdTipoHabitacion &&
                        ofertaEntidad.Fecha_inicio < fechaActual && ofertaEntidad.Fecha_final > fechaActual)
                    {
                        tipoHabitacionEntidad.Precio -=
                            tipoHabitacionEntidad.Precio * ((decimal)ofertaEntidad.Descuento / 100);
                    }
                }
            }

            return tipoHabitacionesEntidad.Select(t => new TipoHabitacion
            {
                IdTipoHabitacion = t.IdTipoHabitacion,
                Nombre = t.Nombre,
                Descripcion = t.Descripcion,
                Precio = t.Precio,
                Imagen = t.Imagen
            });
        }

        private decimal ObtenerDescuentoTemporada(DateTime fechaActual, List<TemporadaEntidad> temporadasEntidad)
        {
            var temporada = temporadasEntidad.FirstOrDefault(t =>
                ValidarFechasSinAnio(fechaActual, t.Fecha_inicio, t.Fecha_final));

            return temporada != null ? ((decimal)temporada.Descuento) / 100 : 0;
        }

        private bool ValidarFechasSinAnio(DateTime dia, DateTime inicioFecha, DateTime finFecha)
        {
            DateTime normalizedDia = new DateTime(2000, dia.Month, dia.Day);
            DateTime normalizedInicio = new DateTime(2000, inicioFecha.Month, inicioFecha.Day);
            DateTime normalizedFin = new DateTime(2000, finFecha.Month, finFecha.Day);

            if (normalizedInicio <= normalizedFin)
            {
                return normalizedDia >= normalizedInicio && normalizedDia <= normalizedFin;
            }
            else
            {
                return normalizedDia >= normalizedInicio || normalizedDia <= normalizedFin;
            }
        }
    }
}