using AppWebPedidos.Models;

namespace AppWebPedidos.Services
{
    public class CarritoService
    {
        private readonly List<CarritoItem> _items = new();

        public IReadOnlyList<CarritoItem> Items => _items;

        public int CantidadTotal => _items.Sum(i => i.Cantidad);

        public decimal Total => _items.Sum(i => i.Subtotal);

        public event Action? OnChange;

        private void NotificarCambio()
        {
            OnChange?.Invoke();
        }

        public void Agregar(Plato plato)
        {
            var itemExistente = _items
                .FirstOrDefault(i => i.IdPlato == plato.IdPlato);

            if (itemExistente is not null)
            {
                itemExistente.Cantidad++;
            }
            else
            {
                _items.Add(new CarritoItem
                {
                    IdPlato = plato.IdPlato,
                    Nombre = plato.Nombre,
                    Precio = plato.Precio,
                    ImagenUrl = plato.ImagenUrl,
                    Cantidad = 1
                });
            }

            NotificarCambio();
        }

        public void AumentarCantidad(int idPlato)
        {
            var item = _items.FirstOrDefault(i => i.IdPlato == idPlato);

            if (item is not null)
            {
                item.Cantidad++;
                NotificarCambio();
            }
        }

        public void DisminuirCantidad(int idPlato)
        {
            var item = _items.FirstOrDefault(i => i.IdPlato == idPlato);

            if (item is null)
                return;

            if (item.Cantidad > 1)
            {
                item.Cantidad--;
            }
            else
            {
                _items.Remove(item);
            }

            NotificarCambio();
        }

        public void Eliminar(int idPlato)
        {
            var item = _items.FirstOrDefault(i => i.IdPlato == idPlato);

            if (item is not null)
            {
                _items.Remove(item);
                NotificarCambio();
            }
        }

        public void Vaciar()
        {
            _items.Clear();
            NotificarCambio();
        }
    }
}