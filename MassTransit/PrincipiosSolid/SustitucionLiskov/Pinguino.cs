namespace MassTransitTest.PrincipiosSolid.SustitucionLiskov
{
    //Clase Pinguino: Es una subclase o derivada de "AveBase". Sobrescribe el método Mover() para especificar cómo se mueve un pingüino, que es deslizándose en la nieve.

    public class Pinguino : AveBase
    {
        public override void Mover() => Console.WriteLine("El pingüino desliza en la nieve");
    }
}
