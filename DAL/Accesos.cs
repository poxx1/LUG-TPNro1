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
            { cn.Close(); return "Conecto a la base de datos"; }

            else
            { cn.Close(); return "No conecta perro"; }
        }

        public DataTable Read(string query)
        {
            var table = new DataTable();
            
            try
            {
                SqlDataAdapter Da = new SqlDataAdapter(query, cn);
                Da.Fill(table);
            }
            catch (Exception e)
            {
                throw e;
            }

            //Cerras la conexion aca
            cn.Close();
            return table;
        }

        public DataSet ReadDS(string query)
        {
            DataSet DS = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(query, cn);
                da.Fill(DS);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            cn.Close();

            return DS;
        }

        public bool Write(string query)
        {
            cn.Open();
            var cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;
            cmd.CommandText = query;

            try
            {
                int response = cmd.ExecuteNonQuery();
                return true;
            }
            catch (SqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
