namespace MassTransitTest.PrincipiosSolid.OCP
{

    //Esta interfaz define una operación con un contrato simple: recibir dos números y devolver un resultado
    public interface IOperacion
    {
        double Operar(double a, double b);
    }
}


//Si en el futuro se requieren más operaciones, como suma o resta, simplemente se pueden añadir nuevas clases
//que implementen la interfaz IOperacion. No hay necesidad de modificar la interfaz original ni las clases que ya la implementan.



//Las clases Multiplicacion y Division están "cerradas" para la modificación, ya que no necesitas cambiarlas para añadir nuevas operaciones. 

//Las clases Multiplicacion y Division están "abiertas" para la extensión, porque puedes crear más clases que implementen IOperacion.



//Por lo tanto, este diseño permite añadir más operaciones en el futuro sin cambiar el código existente,
//lo que es precisamente el núcleo del Principio Abierto/Cerrado.
