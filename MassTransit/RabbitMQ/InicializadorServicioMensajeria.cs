using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace MassTransitTest.RabbitMQ
{
    public class InicializadorServicioMensajeria
    {
        static async Task Main()
        {
            //Se crea una nueva instancia de ServiceCollection, que es un contenedor para registrar servicios para la inyección de dependencias.
            var servicios = new ServiceCollection();


            //Se configura MassTransit en el contenedor de servicios:
            servicios.AddMassTransit(x =>
            {
                x.UsingRabbitMq((contexto, configuracion) =>
                {
                    configuracion.Host("localhost"); // Dirección de la instancia RabbitMQ.
                });
            });

            //Se construye el proveedor de servicios a partir de la colección de servicios.
            var proveedor = servicios.BuildServiceProvider();

            // Inicia MassTransit.
            //Se obtiene una instancia del bus de MassTransit y luego se inicia de manera asíncrona.
            var bus = proveedor.GetRequiredService<IBusControl>();
            await bus.StartAsync();


            //Publicar el Mensaje: Ahora, cuando quieras emitir la "Solicitud de Emisión", simplemente publica el mensaje.
            await bus.Publish<ISolicitudEmision>(new
            {
                Id = Guid.NewGuid(),
                FechaSolicitud = DateTime.UtcNow,
                Detalles = "Detalles de la solicitud"
            });



            //Suscribirse al Mensaje: En otro lugar de tu aplicación, o en una aplicación diferente, puedes suscribirte al mensaje y procesarlo.
            bus.ConnectReceiveEndpoint("nombre_cola", e =>
            {
                e.Consumer<SolicitudEmisionConsumer>();
            });

            //Después de la pausa, se detiene el bus de MassTransit de manera asíncrona.
            await bus.StopAsync();
        }
    }
}
