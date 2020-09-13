using System;
using System.Data.SqlClient;

namespace DAL
{
    public class BDConnection
    {
        //Esta clase no esta implementada, solo esta el codigo. 

        public object Consulta(string query)
        {
            SqlConnection _conexion = new SqlConnection(@"Server= CMD\SQLEXPRESS; Initial Catalog=Bohemia;Integrated Security=True");
            var cmd = new SqlCommand(query, _conexion);
            var objeto = new object();
            var objeto1 = new object();
            cmd.CommandTimeout = 5;
            int counter = 0;

            //Abro la conexion
            try
            {
                _conexion.Open();
            }
            catch (Exception e)
            {
                throw e;
            }

            //Ejecuto la consulta
            try
            {
                using (SqlDataReader dr = cmd.ExecuteReader())

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            objeto = dr[counter];
                            counter++;
                        }
                    }
            }
            catch (Exception e)
            {
                throw e;
            }

            _conexion.Close();

            return objeto;
        }
    }
}
