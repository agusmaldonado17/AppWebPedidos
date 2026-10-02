using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebPedidos.Models
{
    [Table("plato")]
    public class Plato
    {
        [Key]
        [Column("id_plato")]
        public int IdPlato { get; set; }

        [Required(ErrorMessage = "La categoría es obligatoria.")]
        [Range(
            1,
            int.MaxValue,
            ErrorMessage = "Seleccioná una categoría."
        )]
        [Column("id_categoria")]
        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(
            100,
            MinimumLength = 2,
            ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres."
        )]
        [Column("nombre")]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(
            255,
            ErrorMessage = "La descripción no puede superar los 255 caracteres."
        )]
        [Column("descripcion")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio.")]
        [Range(
            0.01,
            99999999.99,
            ErrorMessage = "El precio debe ser mayor a 0."
        )]
        [Column("precio", TypeName = "decimal(10,2)")]
        public decimal Precio { get; set; }

        [MaxLength(500)]
        [Column("imagen_url")]
        public string? ImagenUrl { get; set; }

        [Required]
        [Column("disponible")]
        public bool Disponible { get; set; } = true;

        [ForeignKey(nameof(IdCategoria))]
        public Categoria? Categoria { get; set; }
    }
}