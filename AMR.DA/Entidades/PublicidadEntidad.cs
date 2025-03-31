using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMR.DA.Entidades
{
    [Table("Publicidad")]
    public class PublicidadEntidad
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public string UrlImagen { get; set; }
        [Required]
        public string UrlDestino { get; set; }
        [Required]
        public bool Visible { get; set; }
    }
}
