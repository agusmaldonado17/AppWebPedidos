namespace AppWebPedidos.Services
{
    public interface IWhatsAppService
    {
        Task EnviarHelloWorldAsync(string telefono);

        Task EnviarConfirmacionPedidoAsync(
            string telefono,
            string nombreCliente,
            int idPedido,
            decimal total,
            string estado);
    }
}