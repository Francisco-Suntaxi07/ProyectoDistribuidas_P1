using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlibliotecaApp.Models
{
    public class PrestamoModel
    {
        [Key]
        [StringLength(8)]
        public string id_prestamo { get; set; }

        [Required]
        [StringLength(8)]
        public string id_libro { get; set; }

        [Required]
        [StringLength(16)]
        public string id_cliente { get; set; }

        public DateTime fecha_prestamo { get; set; }

        public DateTime fecha_devolucion { get; set; }

        public decimal precio_prestamo { get; set; }

        public decimal multa_prestamo { get; set; }

        [StringLength(256)]
        public string observaciones_prestamo { get; set; }
    }
}