using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebPedidos.Models
{
    [Table("pedido")]
    public class Pedido
    {
        [Key]
        [Column("id_pedido")]
        public int IdPedido { get; set; }

        [Required(ErrorMessage = "El nombre del cliente es obligatorio.")]
        [StringLength(
            150,
            MinimumLength = 2,
            ErrorMessage = "Ingresá un nombre válido."
        )]
        [Column("nombre_cliente")]
        public string NombreCliente { get; set; } = string.Empty;

        [StringLength(
            30,
            ErrorMessage = "El teléfono no puede superar los 30 caracteres."
        )]
        [Column("telefono")]
        public string? Telefono { get; set; }

        [StringLength(
            255,
            ErrorMessage = "La dirección no puede superar los 255 caracteres."
        )]
        [Column("direccion")]
        public string? Direccion { get; set; }

        [Required]
        [Column("fecha")]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required]
        [MaxLength(30)]
        [Column("estado")]
        public string Estado { get; set; } = "Pendiente";

        [Required]
        [Range(0.01, 99999999.99)]
        [Column("total", TypeName = "decimal(10,2)")]
        public decimal Total { get; set; }

        public ICollection<DetallePedido> Detalles { get; set; }
            = new List<DetallePedido>();
    }
}