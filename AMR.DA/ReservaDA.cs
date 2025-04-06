using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMR.DA.Contexto;
using AMR.DA.Entidades;
using AMR.DA.Interfaces;
using AMR.Dominio;
using Microsoft.EntityFrameworkCore;

namespace AMR.DA
{
    public class ReservaDA : IReservaDA
    {

        private readonly ContextoBD _context;

        public ReservaDA(ContextoBD context)
        {
            _context = context;
        }

        public async Task<(bool, string)> RegistrarReserva(int idTipoHabitacion, string nombre, string apellido, string correo, string tarjeta, DateTime fechaLlegada, DateTime fechaSalida)
        {

            string codigoReserva;
            do
            {
                codigoReserva = GenerarCodigoReserva();
            }
            while (await _context.Reserva.AnyAsync(r => r.CodigoReserva == codigoReserva));

            string numeroTransaccion;
            do
            {
                numeroTransaccion = GenerarNumeroTransaccion();
            }
            while (await _context.Reserva.AnyAsync(r => r.NumeroTransaccion == numeroTransaccion));

            var habitacionDisponible = await _context.Habitacion.FirstOrDefaultAsync(h =>
                h.IdTipoHabitacion == idTipoHabitacion &&
                !_context.Reserva.Any(r => r.IdHabitacion == h.IdHabitacion &&
                    r.FechaLlegada < fechaSalida && r.FechaSalida > fechaLlegada));

            if (habitacionDisponible == null)
            {
                return (false, "No hay habitaciones disponibles para esas fechas.");
            }

            ReservaEntidad entidad = new ReservaEntidad
            {
                CodigoReserva = codigoReserva,
                NumeroTransaccion = numeroTransaccion,
                IdHabitacion = habitacionDisponible.IdHabitacion,
                Nombre = nombre,
                Apellidos = apellido,
                Email = correo,
                Tarjeta = tarjeta,
                FechaLlegada = fechaLlegada,
                FechaSalida = fechaSalida
            };

            await _context.Reserva.AddAsync(entidad);
            await _context.SaveChangesAsync();
            return (true, "Reserva exitosa. Código de reserva: " + codigoReserva);
        }

        private string GenerarCodigoReserva()
        {
            const string letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numeros = "0123456789";
            Random random = new Random();

            string parteLetras1 = new string(Enumerable.Repeat(letras, 8)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            string parteNumeros = new string(Enumerable.Repeat(numeros, 4)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            string parteLetras2 = new string(Enumerable.Repeat(letras, 2)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            return parteLetras1 + parteNumeros + parteLetras2;
        }

        private string GenerarNumeroTransaccion()
        {
            const string numeros = "0123456789";
            Random random = new Random();
            string transaccion = new string(Enumerable.Repeat(numeros, 9)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            return transaccion;
        }



    }
}
