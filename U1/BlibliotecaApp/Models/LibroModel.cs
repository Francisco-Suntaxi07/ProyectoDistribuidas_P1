using System;
using System.ComponentModel.DataAnnotations;

namespace BlibliotecaApp.Models
{
    public class LibroModel
    {
        [Key]
        [StringLength(8)]
        public string id_libro { get; set; }
        [Required]
        [StringLength(8)]
        public string id_autor { get; set; }
        [Required]
        [StringLength(8)]
        public string id_genero { get; set; }
        [Required]
        [StringLength(8)]
        public string id_editorial { get; set; }
        [Required]
        [StringLength(64)]
        public string titulo_libro { get; set; }

        public DateTime fecha_publicacion { get; set; }
        public int num_paginas { get; set; }
        [Required]
        [StringLength(16)]
        public string estado_libro { get; set; }
        public int cantidad_libro { get; set; }
    }
}