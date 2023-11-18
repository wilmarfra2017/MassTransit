namespace MassTransitTest.PrincipiosSolid.DependencyInjection
{
    // Interfaz para definir el comportamiento de una notificación.
    public interface INotificacion
    {
        void Enviar(string mensaje);
    }

    public class EmailNotificacion : INotificacion
    {
        public void Enviar(string mensaje) => Console.WriteLine($"Enviando email: {mensaje}");

    }

    // Nueva clase para enviar notificaciones por SMS
    public class SmsNotificacion : INotificacion
    {
        public void Enviar(string mensaje) => Console.WriteLine($"Enviando SMS: {mensaje}");
    }

    public class Notificador
    {
        private readonly INotificacion _notificacion;

        public Notificador(INotificacion notificacion)
        {
            _notificacion = notificacion;
        }

        public void EjecutarNotificacion(string mensaje)
        {
            _notificacion.Enviar(mensaje);
        }

    }

    class Program
    {
        static void Main()
        {
            // Ejemplo para DIP -EMAIL

            //instanciación de una implementación concreta de la interfaz
            INotificacion notificacionEmail = new EmailNotificacion();

            //pasa la instancia a la clase Notificador
            var notificadorEmail = new Notificador(notificacionEmail);

            notificadorEmail.EjecutarNotificacion("Hola mundo SOLID por EMAIL!");


            // Ejemplo con SMS
            INotificacion notificacionSms = new SmsNotificacion();
            var notificadorSms = new Notificador(notificacionSms);
            notificadorSms.EjecutarNotificacion("Hola mundo SOLID por SMS!");


        }
    }
}
