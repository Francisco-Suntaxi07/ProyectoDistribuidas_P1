using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlibliotecaApp.Models
{
    public class LibroModel
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

        public AutorModel Autor { get; set; }
        public GeneroModel Genero { get; set; }
        public EditorialModel Editorial { get; set; }
    }
}