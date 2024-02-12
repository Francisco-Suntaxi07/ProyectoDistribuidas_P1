using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace API_Libros_BL.DTO
{
    public class AutorDTO
    {
        [Required(ErrorMessage ="El campo de id autor es requerido")]
        [StringLength(8)]
        public String id_autor { get; set; }

        [Required(ErrorMessage = "El campo de nombre de autor es requerido")]
        [StringLength(64)]
        public String nombre_autor { get; set; }

        [Required(ErrorMessage = "El campo nacionalidad autor es requerido")]
        [StringLength(8)]
        public String nacionalidad_autor { get; set; }
    }
}
