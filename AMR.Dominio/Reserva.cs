using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMR.Dominio
{
    public class Reserva
    {
        public int IdReserva { get; set; }                    
        public string CodigoReserva { get; set; }      
        public string NumeroTransaccion { get; set; }  
        public int IdHabitacion { get; set; }          
        public string Nombre { get; set; }             
        public string Apellidos { get; set; }          
        public string Email { get; set; }              
        public string Tarjeta { get; set; }            
        public DateTime FechaLlegada { get; set; }      
        public DateTime FechaSalida { get; set; }         
    }
}
