using System.ComponentModel.DataAnnotations;
namespace PrestamoApi.Model
{
    public class CustomerModel
    {
        [Key]
        [StringLength(16)]
        public string id_cliente { get; set; }

        [StringLength(64)]
        public string? nombre_cliente { get; set; }

        [StringLength(64)]
        public string? direccion_cliente { get; set; }

        [StringLength(16)]
        public string? telf_cliente { get; set; }

        [StringLength(64)]
        public string? email_cliente { get; set; }

        public int? edad_cliente { get; set; }
    }
}
