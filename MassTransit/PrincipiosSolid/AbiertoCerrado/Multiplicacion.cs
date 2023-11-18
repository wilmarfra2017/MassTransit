namespace MassTransitTest.PrincipiosSolid.OCP
{
    //CLase Multiplicacion: Esta clase implementa la interfaz IOperacion.
    //Esto significa que estas clases proporcionan sus propias implementaciones específicas del método Operar
    //sin cambiar la definición o comportamiento de la interfaz en sí.

    public class Multiplicacion : IOperacion
    {
        public double Operar(double a, double b) => a * b;
    }
}
