using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Libros_BL.Models
{
    [Table("Editorial", Schema = "dbo")]
    public class Editorial
    {
        [Key]
        public String id_editorial { get; set; }
        public String nombre_editorial { get; set; }
        public String direccion_editorial { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
    }
}
