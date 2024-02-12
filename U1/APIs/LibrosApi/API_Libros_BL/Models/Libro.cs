using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Libros_BL.Models
{
    [Table("Libro", Schema = "dbo")]
    public class Libro
    {
        [Key]
        public String id_libro { get; set; }

        [ForeignKey("Autor")]
        public String id_autor { get; set; }

        [ForeignKey("Genero")]
        public String id_genero { get; set; }

        [ForeignKey("Editorial")]
        public String id_editorial { get; set; }
        public String titulo_libro { get; set; }
        public DateTime fecha_publicacion { get; set; }
        public int num_paginas { get; set; }
        public String estado_libro { get; set; }
        public int cantidad_libro { get; set; }

        public Autor Autor { get; set; }
        public Genero  Genero { get; set; }
        public Editorial Editorial { get; set; }

    }
}
