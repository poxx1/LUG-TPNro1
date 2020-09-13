using DAL;

namespace Negocio
{
    class TestConnection
    {
        Accesos c = new Accesos();

        //Testeo la coneccion a la bd.

        public string Test()
        {
            return c.TestBD();
        }
    }
}
