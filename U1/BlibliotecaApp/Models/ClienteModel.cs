using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlibliotecaApp.Models
{
    public class ClienteModel
    {
        [Key]
        [StringLength(16)]
        public string id_cliente { get; set; }

        [StringLength(64)]
        public string nombre_cliente { get; set; }

        [StringLength(64)]
        public string direccion_cliente { get; set; }

        [StringLength(16)]
        public string telf_cliente { get; set; }

        [StringLength(64)]
        public string email_cliente { get; set; }

        public int edad_cliente { get; set; }
    }
}