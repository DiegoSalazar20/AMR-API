using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMR.DA.Entidades
{
    [Table("Home")]
    public class HomeEntidad
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Imagen { get; set; } = string.Empty; 

        [Required]
        public string Contenido { get; set; } = string.Empty; 
    }
}

