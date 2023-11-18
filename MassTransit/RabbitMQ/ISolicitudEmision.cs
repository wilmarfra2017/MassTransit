namespace MassTransitTest.RabbitMQ
{
    //Primero, necesitas definir el mensaje que representa la "Solicitud de Emisión"
    public interface ISolicitudEmision
    {
        Guid Id { get; }
        // Otros campos relevantes aquí, por ejemplo:
        DateTime FechaSolicitud { get; }
        string Detalles { get; }

    }
}
