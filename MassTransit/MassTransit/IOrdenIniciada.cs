namespace MassTransitTest.MassTransit
{
    public interface IOrdenIniciada
    {
        Guid IdOrden { get; }
        Guid IdProducto { get; }
        int Cantidad { get; }
        Guid IdCliente { get; }
    }

}
