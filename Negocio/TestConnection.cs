using DAL;

namespace Negocio
{
    public class TestConnection
    {
        protected string A { get; set; }
        
        //Testeo la coneccion a la bd.

        public string Test()
        { 
            Accesos c = new Accesos();
            c.TestBD();
            return c.TestBD();
        }

        public string Test2()
        {
            BDConnection c = new BDConnection();
            A = c.Consulta("SELECT * FROM [Bohemia].[dbo].[Usuarios] WHERE [User] = 'poxi';").ToString();
            return A;
        }

        public string Test2(string sel)
        {
            BDConnection c = new BDConnection();
            A = c.Consulta("SELECT "+ sel + " FROM [Bohemia].[dbo].[Usuarios] WHERE [User] = 'poxi';").ToString();
            return A;
        }
    }
}
