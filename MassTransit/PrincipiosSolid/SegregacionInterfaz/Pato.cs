namespace MassTransitTest.PrincipiosSolid.SegregacionInterfaz
{
    // En lugar de tener una interfaz grande, la separamos en varias (más pequeñas y específicas.)
    
    public class Pato : IPuedeNadar, IPuedeVolar
    {
        public void Nadar()
        {
            Console.WriteLine("El pato nada");
        }

        public void Volar()
        {
            Console.WriteLine("El pato vuela");
        }
    }
}
