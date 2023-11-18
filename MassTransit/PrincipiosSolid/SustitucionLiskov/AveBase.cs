namespace MassTransitTest.PrincipiosSolid.SustitucionLiskov
{
    //Clase AveBase: Esta es la clase base que tiene un método Mover(). El método representa cómo se mueve una ave en general.

    public class AveBase
    {
        public virtual void Mover() => Console.WriteLine("Esta ave se mueve");
    }
}



//El punto clave del Principio Abierto/Cerrado es que las subclases no deben alterar las expectativas de los comportamientos definidos por la superclase (clase base)


//La expectativa es que una ave puede moverse, mientras que un pingüino se mueve de manera diferente a otras aves
//aún se adhiere a la expectativa general de que se puede mover. Por lo tanto, este diseño sigue el LSP.