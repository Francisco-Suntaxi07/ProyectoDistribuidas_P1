using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BibliotecaApp.Controllers
{
    public class AutorController
    {
        [Key]
        [StringLength(8)]
        public string id_autor { get; set; }

        [Required]
        [StringLength(64)]
        public string nombre_autor { get; set; }

        [Required]
        [StringLength(16)]
        public string nacionalidad_autor { get; set; }
    }
}