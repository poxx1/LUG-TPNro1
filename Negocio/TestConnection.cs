using DAL;
using Mapper;

namespace Negocio
{
    public class TestConnection
    {
        protected string A { get; set; }
       
        public string Test()
        { 
            Accesos c = new Accesos();
            c.TestBD();
            return c.TestBD();
        }

        #region Login Encriptado/Desencriptado

        public string SelectCript(string usr)
        {
            var mj = new MTest();
            return mj.SelectCript(usr);
        }
        public string SelectCript(string sel, string usr)
        {
            var mj = new MTest();
            return mj.SelectCript(sel,usr);
        }
   
        #endregion
        
    }
}
