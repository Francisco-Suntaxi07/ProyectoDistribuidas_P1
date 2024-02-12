using System.ComponentModel.DataAnnotations;

namespace BlibliotecaApp.Models
{
    public class EditorialModel
    {
        [Key]
        [StringLength(8)]
        public string id_editorial { get; set; }

        [Required]
        [StringLength(64)]
        public string nombre_editorial { get; set; }

        [Required]
        [StringLength(64)]
        public string direccion_editorial { get; set; }
    }
}