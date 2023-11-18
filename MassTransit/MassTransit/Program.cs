
using MassTransit;
using MassTransitTest.MassTransit;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static async Task Main()
    {
        //Se crea una nueva instancia de ServiceCollection, que es un contenedor para registrar servicios para la inyección de dependencias.
        var servicios = new ServiceCollection();

        //  se configura MassTransit en el contenedor de servicios:
        servicios.AddMassTransit(x =>
        {

            //registra la máquina de estados OrdenStateMachine y la saga OrdenSaga usando un repositorio en memoria.
            x.AddSagaStateMachine<OrdenStateMachine, OrdenSaga>()
                .InMemoryRepository();


            //indica que se usará un bus en memoria (útil para pruebas y desarrollo) y se configuran sus puntos finales.
            x.UsingInMemory((contexto, cfg) =>
            {
                cfg.ConfigureEndpoints(contexto);
            });
        });


        //Se construye el proveedor de servicios a partir de la colección de servicios.
        var proveedor = servicios.BuildServiceProvider();

        // Inicia MassTransit.
        //Se obtiene una instancia del bus de MassTransit y luego se inicia de manera asíncrona.
        var bus = proveedor.GetRequiredService<IBusControl>();
        await bus.StartAsync();

        // Publica un mensaje para iniciar una orden.
        var idOrden = NewId.NextGuid();
        //Estas líneas publican tres mensajes diferentes al bus:
        await bus.Publish<IOrdenIniciada>(new { IdOrden = idOrden, IdProducto = NewId.NextGuid(), Cantidad = 1, IdCliente = NewId.NextGuid() });
        await bus.Publish<IPagoProcesado>(new { IdOrden = idOrden, Exito = true });
        await bus.Publish<IOrdenCompletada>(new { IdOrden = idOrden });

        // Espera antes de finalizar.
        //Se introduce una pausa de 5 segundos (5000 milisegundos) antes de proceder. Esto es probablemente para dar tiempo a MassTransit para procesar los mensajes publicados.
        await Task.Delay(5000);

        //Después de la pausa, se detiene el bus de MassTransit de manera asíncrona.
        await bus.StopAsync();
    }
}



//En resumen, esta clase Program inicializa
//y configura MassTransit para trabajar en memoria, publica una serie de mensajes
//para simular el proceso de una orden (inicio, procesamiento de pago y finalización), y luego detiene el bus. 



