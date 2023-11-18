using MassTransit;

namespace MassTransitTest.MassTransit
{
    // Implementación de las interfaces usando records.
    public record OrdenIniciada(Guid IdOrden, Guid IdProducto, int Cantidad, Guid IdCliente) : IOrdenIniciada;
    public record PagoProcesado(Guid IdOrden, bool Exito) : IPagoProcesado;
    public record OrdenCompletada(Guid IdOrden) : IOrdenCompletada;


    // Definición de la saga.
    public class OrdenSaga : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public int EstadoActual { get; set; }
    }
}
