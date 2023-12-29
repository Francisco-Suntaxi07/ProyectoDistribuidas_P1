using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Libros_BL.Models
{
    [Table("Autor", Schema = "dbo")]
    public class Autor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public String id_autor { get; set; }
        public String nombre_autor { get; set; }
        public String nacionalidad_autor { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
    }
}
