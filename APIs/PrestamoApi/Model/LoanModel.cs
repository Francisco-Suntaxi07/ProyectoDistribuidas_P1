using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrestamoApi.Model
{
    public class LoanModel
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

        public DateTime? fecha_prestamo { get; set; }

        public DateTime? fecha_devolucion { get; set; }

        [Column(TypeName = "numeric(4,2)")]
        public decimal? precio_prestamo { get; set; }

        [Column(TypeName = "numeric(4,2)")]
        public decimal? multa_prestamo { get; set; }

        [StringLength(256)]
        public string? observaciones_prestamo { get; set; }

    }
}
