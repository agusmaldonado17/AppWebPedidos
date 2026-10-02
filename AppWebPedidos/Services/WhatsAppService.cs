using System.Globalization;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace AppWebPedidos.Services
{
    public class WhatsAppService : IWhatsAppService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public WhatsAppService(
            HttpClient httpClient,
            IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }


        public async Task EnviarHelloWorldAsync(string telefono)
        {
            var template = new
            {
                name = "hello_world",

                language = new
                {
                    code = "en_US"
                }
            };

            await EnviarTemplateAsync(
                telefono,
                template
            );
        }


        public async Task EnviarConfirmacionPedidoAsync(
            string telefono,
            string nombreCliente,
            int idPedido,
            decimal total,
            string estado)
        {
            var nombreTemplate =
                _configuration["WhatsApp:TemplateName"]
                ?? "confirmacion_pedido";

            var idiomaTemplate =
                _configuration["WhatsApp:TemplateLanguage"]
                ?? "es_AR";


            var totalFormateado =
                total.ToString(
                    "N2",
                    CultureInfo.GetCultureInfo("es-AR")
                );


            var template = new
            {
                name = nombreTemplate,

                language = new
                {
                    code = idiomaTemplate
                },

                components = new[]
                {
                    new
                    {
                        type = "body",

                        parameters = new[]
                        {
                            new
                            {
                                type = "text",
                                text = nombreCliente
                            },

                            new
                            {
                                type = "text",
                                text = idPedido.ToString()
                            },

                            new
                            {
                                type = "text",
                                text = totalFormateado
                            },

                            new
                            {
                                type = "text",
                                text = estado
                            }
                        }
                    }
                }
            };


            await EnviarTemplateAsync(
                telefono,
                template
            );
        }


        private async Task EnviarTemplateAsync(
            string telefono,
            object template)
        {
            var token =
                _configuration["WhatsApp:AccessToken"];

            var phoneNumberId =
                _configuration["WhatsApp:PhoneNumberId"];

            var apiVersion =
                _configuration["WhatsApp:GraphApiVersion"];


            if (string.IsNullOrWhiteSpace(token))
            {
                throw new InvalidOperationException(
                    "No está configurado WhatsApp:AccessToken."
                );
            }


            if (string.IsNullOrWhiteSpace(phoneNumberId))
            {
                throw new InvalidOperationException(
                    "No está configurado WhatsApp:PhoneNumberId."
                );
            }


            if (string.IsNullOrWhiteSpace(apiVersion))
            {
                throw new InvalidOperationException(
                    "No está configurado WhatsApp:GraphApiVersion."
                );
            }


            var telefonoNormalizado =
                new string(
                    telefono
                        .Where(char.IsDigit)
                        .ToArray()
                );


            var url =
                $"https://graph.facebook.com/{apiVersion}/{phoneNumberId}/messages";


            var body = new
            {
                messaging_product = "whatsapp",

                to = telefonoNormalizado,

                type = "template",

                template
            };


            using var request =
                new HttpRequestMessage(
                    HttpMethod.Post,
                    url
                );


            request.Headers.Authorization =
                new AuthenticationHeaderValue(
                    "Bearer",
                    token
                );


            request.Content =
                JsonContent.Create(body);


            using var response =
                await _httpClient.SendAsync(request);


            var contenido =
                await response.Content.ReadAsStringAsync();


            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException(
                    $"Error de WhatsApp API: " +
                    $"{(int)response.StatusCode} - {contenido}"
                );
            }
        }
    }
}