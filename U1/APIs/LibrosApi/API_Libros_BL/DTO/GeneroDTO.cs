using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Libros_BL.DTO
{
    public class GeneroDTO
    {
        [Required]
        [StringLength(8)]
        public String id_genero { get; set; }

        [Required]
        [StringLength(64)]
        public String nombre_genero { get; set; }

        [Required]
        [StringLength(64)]
        public String descripcion_genero { get; set; }
    }
}
