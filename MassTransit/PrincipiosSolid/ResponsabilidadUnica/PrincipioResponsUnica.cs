namespace MassTransitTest.PrincipiosSolid.SRP
{
    //S - PRINCIPIO DE RESPONSABILIDAD UNICA (SRP)

    //Una clase que solo tiene la responsabilidad de manejar operaciones de una calculadora basica
    public class PrincipioResponsUnica
    {

        public double Sumar(double a, double b) => a + b;
        public double Restar(double a, double b) => a - b;
        public double Multiplicar(double a, double b) => a * b;
        public double Dividir(double a, double b) => a / b;

    }
}
