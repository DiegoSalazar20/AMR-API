using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMR.DA.Entidades
{
    [Table("comollegar")]
    public class ComoLlegarEntidad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUbicacion { get; set; }

        [MaxLength(500)]
        public string Descripcion { get; set; }

        [Column(TypeName = "decimal(9,6)")]
        public decimal Latitud { get; set; }

        [Column(TypeName = "decimal(9,6)")]
        public decimal Longitud { get; set; }
    }
}
