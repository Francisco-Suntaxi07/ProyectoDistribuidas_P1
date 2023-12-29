using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Libros_BL.DTO
{
    public class EditorialDTO
    {
        [Required]
        [StringLength(8)]
        public String id_editorial { get; set; }

        [Required]
        [StringLength(64)]
        public String nombre_editorial { get; set; }

        [Required]
        [StringLength(64)]
        public String direccion_editorial { get; set; }
    }
}
