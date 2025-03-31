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

        public async Task<(bool, string)> RegistrarReserva(Reserva reserva)
        {
            if (reserva == null)
                return (false, null);

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

            ReservaEntidad entidad = new ReservaEntidad
            {
                CodigoReserva = codigoReserva,
                NumeroTransaccion = numeroTransaccion,
                IdHabitacion = reserva.IdHabitacion,
                Nombre = reserva.Nombre,
                Apellidos = reserva.Apellidos,
                Email = reserva.Email,
                Tarjeta = reserva.Tarjeta,
                FechaLlegada = reserva.FechaLlegada,
                FechaSalida = reserva.FechaSalida,
            };

            await _context.Reserva.AddAsync(entidad);
            await _context.SaveChangesAsync();
            return (true, codigoReserva);
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
