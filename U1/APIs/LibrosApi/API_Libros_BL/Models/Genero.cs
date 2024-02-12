using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Libros_BL.Models
{
    [Table("Genero", Schema = "dbo")]
    public class Genero
    {
        [Key]
        public String id_genero { get; set; }
        public String nombre_genero { get; set; }
        public String descripcion_genero { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
    }
}
