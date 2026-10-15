namespace AppWebPedidos.Models
{
    public class CarritoItem
    {
        public int IdPlato { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public decimal Precio { get; set; }

        public string? ImagenUrl { get; set; }

        public int Cantidad { get; set; } = 1;

        public string? Observacion { get; set; }

        public decimal Subtotal => Precio * Cantidad;
    }
}