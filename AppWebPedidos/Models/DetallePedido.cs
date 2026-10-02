using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebPedidos.Models
{
    [Table("detalle_pedido")]
    public class DetallePedido
    {
        [Key]
        [Column("id_detalle")]
        public int IdDetalle { get; set; }


        [Required]
        [Column("id_pedido")]
        public int IdPedido { get; set; }


        [Required]
        [Column("id_plato")]
        public int IdPlato { get; set; }


        [Required]
        [Range(
            1,
            100,
            ErrorMessage = "La cantidad debe ser mayor a 0."
        )]
        [Column("cantidad")]
        public int Cantidad { get; set; }


        [Required]
        [Range(
            0.01,
            99999999.99,
            ErrorMessage = "El precio debe ser mayor a 0."
        )]
        [Column("precio_unitario", TypeName = "decimal(10,2)")]
        public decimal PrecioUnitario { get; set; }


        [MaxLength(255)]
        [Column("observacion")]
        public string? Observacion { get; set; }


        [ForeignKey(nameof(IdPedido))]
        public Pedido? Pedido { get; set; }


        [ForeignKey(nameof(IdPlato))]
        public Plato? Plato { get; set; }
    }
}