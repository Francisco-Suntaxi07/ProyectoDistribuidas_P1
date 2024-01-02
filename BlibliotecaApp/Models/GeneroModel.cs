using System.ComponentModel.DataAnnotations;

namespace BlibliotecaApp.Models
{
    public class GeneroModel
    {
        [Key]
        [StringLength(8)]
        public string id_genero { get; set; }

        [Required]
        [StringLength(64)]
        public string nombre_genero { get; set; }

        [Required]
        [StringLength(64)]
        public string descripcion_genero { get; set; }
    }
}