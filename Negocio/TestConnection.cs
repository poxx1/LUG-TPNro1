using DAL;

namespace Negocio
{
    public class TestConnection
    {
        Accesos c = new Accesos();

        //Testeo la coneccion a la bd.

        public string Test()
        {
            c.TestBD();
            return c.TestBD();
        }
    }
}
