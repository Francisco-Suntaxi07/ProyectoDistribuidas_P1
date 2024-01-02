using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace BlibliotecaApp.Models
{
    public class EditorialModel
    {
        [Key]
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