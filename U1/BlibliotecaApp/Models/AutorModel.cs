using System.ComponentModel.DataAnnotations;

namespace BlibliotecaApp.Models
{
    public class AutorModel
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