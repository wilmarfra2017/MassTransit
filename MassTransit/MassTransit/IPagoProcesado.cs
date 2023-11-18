namespace MassTransitTest.MassTransit
{
    public interface IPagoProcesado
    {
        Guid IdOrden { get; }
        bool Exito { get; }
    }
}
