using API_Libros_BL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Libros_BL.DTO
{
    public class LibroDTO
    {
        [Required]
        [StringLength(8)]
        public String id_libro { get; set; }

        public String id_autor { get; set; }

        public String id_genero { get; set; }

        public String id_editorial { get; set; }

        public String titulo_libro { get; set; }

        public DateTime fecha_publicacion { get; set; }

        public int num_paginas { get; set; }

        public String estado_libro { get; set; }

        public int cantidad_libro { get; set; }

        public AutorDTO Autor { get; set; }
        public GeneroDTO Genero { get; set; }
        public EditorialDTO Editorial { get; set; }
    }
}
