using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Accesos
    {
        //PC laburo: protected SqlConnection cn = new SqlConnection(@"Server=CPX-L7QBTQ41YG6\SQLEXPRESS01;Initial Catalog=Bohemia;Integrated Security=True");
        protected SqlConnection cn = new SqlConnection(@"Server= CMD\SQLEXPRESS; Initial Catalog=Bohemia;Integrated Security=True");
        
        public string TestBD()
        {
            cn.Open();

            if (cn.State == ConnectionState.Open)
            { cn.Close(); return "Conecto"; }

            else
            { cn.Close(); return "No conecta perro"; }
        }

        public bool Read()
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;
            cmd.CommandText = "SELECT * FROM [Bohemia].[dbo].[Usuarios] WHERE [User] = 'poxi';";

            DataSet ds = new DataSet();

            try
            {
                int respuesta = cmd.ExecuteNonQuery();
                SqlDataAdapter Da = new SqlDataAdapter(cmd.CommandText, cn);
                Da.Fill(ds);
                int b = 0;
                foreach (DataRow fila in ds.Tables[0].Rows)
                {
                     string a = fila[b].ToString();
                    b++;    
                }
                //Cerras la conexion aca
                cn.Close();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
    }
}
