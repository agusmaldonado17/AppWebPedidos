using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebPedidos.Models
{
    [Table("categoria")]
    public class Categoria
    {
        [Key]
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

        [Required]
        [Column("activo")]
        public bool Activo { get; set; } = true;
    }
}