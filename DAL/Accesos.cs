using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Accesos
    {
        protected SqlConnection cn = new SqlConnection(@"Server=CPX-L7QBTQ41YG6\SQLEXPRESS01;Initial Catalog=Bohemia;Integrated Security=True");
        //protected SqlConnection cn = new SqlConnection(@Server=\SQLEXPRESS;Initial Catalog=Bohemia;Integrated Security=True");
        //CPX-L7QBTQ41YG6\SQLEXPRESS01

        public string TestBD()
        {
            cn.Open();

            if (cn.State == ConnectionState.Open)
                return "Conecto";
            
            else
                return "No conecta perro";
        }

        public bool Consulta()
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;
            cmd.CommandText = "SELECT * FROM [Bohemia].[dbo].[Usuarios] Where Pass='1234';";

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
