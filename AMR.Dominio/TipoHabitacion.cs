﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMR.Dominio
{
    public class TipoHabitacion
    {
        public int IdTipoHabitacion { get; set; }            
        public string Nombre { get; set; }     
        public string Descripcion { get; set; } 
        public decimal Precio { get; set; }    
        public string Imagen { get; set; }
    }
}
