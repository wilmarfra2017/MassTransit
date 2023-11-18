
using MassTransit;

namespace MassTransitTest.RabbitMQ
{
    public class SolicitudEmisionConsumer : IConsumer<ISolicitudEmision>
    {
        public async Task Consume(ConsumeContext<ISolicitudEmision> context)
        {
            var mensaje = context.Message;

            // Procesar el mensaje aquí.
            await AlgunaOperacionAsincrona(mensaje);
        }

        private async Task AlgunaOperacionAsincrona(ISolicitudEmision mensaje)
        {
            // Simulando alguna operación asincrónica con un retraso.
            await Task.Delay(2000); // Espera de 2 segundos.


            Console.WriteLine($"Mensaje ID: {mensaje.Id}, Fecha: {mensaje.FechaSolicitud}, Detalles: {mensaje.Detalles}");
        }

    }
}
