using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Accesos
    {
        protected SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Bohemia;Integrated Security=True");

        public string TestBD()
        {
            cn.Open();

            if (cn.State == ConnectionState.Open)
                return "Conecto";
            
            else
                return "No conecta perro";
        }
        
    }
}
