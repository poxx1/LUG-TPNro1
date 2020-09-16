using DAL;

namespace Mapper
{
    public class MTest
    {
        protected string A { get; set; }

        public string SelectCript(string usr)
        {
            BDConnection c = new BDConnection();
            A = c.Consulta("SELECT * FROM [Bohemia].[dbo].[Usuarios] WHERE [User] = '" + usr + "';").ToString();
            return A;
        }

        public string SelectCript(string sel, string usr)
        {
            BDConnection c = new BDConnection();
            A = c.Consulta("SELECT " + sel + " FROM [Bohemia].[dbo].[Usuarios] WHERE [User] = '" + usr + "';").ToString();
            return A;
        }

    }
}
