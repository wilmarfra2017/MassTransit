using MassTransit;

namespace MassTransitTest.MassTransit
{
    // Configuración de la máquina de estados de la saga.
    public class OrdenStateMachine : MassTransitStateMachine<OrdenSaga>
    {

        public OrdenStateMachine()
        {
            // Define el estado inicial de la saga.
            Initially(
                When(OrdenIniciada)
                    .Then(contexto =>
                    {
                        // Ejecuta algo cuando se inicia una orden.
                        Console.WriteLine($"Orden iniciada: {contexto.Message.IdOrden}");
                    })
                    .TransitionTo(Iniciada)
            );

            // Define el comportamiento cuando se procesa un pago.
            During(Iniciada,
                When(PagoProcesado)
                    .Then(contexto =>
                    {
                        // Ejecuta algo cuando se procesa un pago.
                        Console.WriteLine($"Pago procesado para la orden: {contexto.Message.IdOrden}. Exito: {contexto.Message.Exito}");
                    })
                    .TransitionTo(Pagada)
            );

            // Define el comportamiento cuando se completa una orden.
            During(Pagada,
                When(OrdenCompletada)
                    .Then(contexto =>
                    {
                        // Ejecuta algo cuando se completa una orden.
                        Console.WriteLine($"Orden completada: {contexto.Message.IdOrden}");
                    })
                    .Finalize()
            );

            // Define el final de la saga.
            SetCompletedWhenFinalized();
        }

        // Estados de la saga.
        public State? Iniciada { get; private set; }
        public State? Pagada { get; private set; }

        // Eventos que pueden disparar transiciones en la saga.
        public Event<IOrdenIniciada>? OrdenIniciada { get; private set; }
        public Event<IPagoProcesado>? PagoProcesado { get; private set; }
        public Event<IOrdenCompletada>? OrdenCompletada { get; private set; }

    }
}
