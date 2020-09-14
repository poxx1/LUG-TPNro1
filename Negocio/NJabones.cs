using System;
using System.Collections.Generic;
using System.Data;
using DAL;
using BE;

namespace BE
{
    public class NJabones
    {
      
        public List<BE.Jabones> CargarJabones()
        {
            DataSet ds = new DataSet();
            Accesos datos = new Accesos();

            string query = "SELECT * FROM Bohemia.dbo.Jabones";
            
            ds = datos.ReadDS(query);

            var listaJabones = new List<BE.Jabones>();

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in ds.Tables[0].Rows)
                {
                    var jabon = new BE.Jabones();
                    
                    //ID
                    jabon.Id = Convert.ToInt32(fila[0]);
                    //Color
                    jabon.Color = fila[1].ToString();
                    //Aroma
                    jabon.Aroma = fila[2].ToString();
                    //Base
                    jabon.Base = fila[3].ToString();
                    //Cantidad
                    jabon.Cantidad = Convert.ToInt32(fila[4]);

                    listaJabones.Add(jabon);
                }
            }
            else
            {
                listaJabones = null;
            }
            return listaJabones;
        }

        public bool Insert(BE.Jabones jabon)
        {
            var d = new Accesos();
            string query = "INSERT into Jabones (ID_Jabon, Color, Aroma, Base, Cantidad) VALUES ('"+jabon.Id
                +"','"+jabon.Color+"','"+jabon.Aroma+"','"+jabon.Base+"',"+jabon.Cantidad+")";

            return d.Escribir(query);
        }

        public bool Update(BE.Jabones jabon)
        {
            var d = new Accesos();

            string query = "UPDATE Jabones SET Color = '" + jabon.Color + "', Aroma ='" +
                jabon.Aroma +"', Base = '" + jabon.Base + "', Cantidad = " + jabon.Cantidad +
                "WHERE Id_Jabon ="+jabon.Id+"";

            return d.Escribir(query);
        }

        public bool Delete(BE.Jabones jabon)
        {
            var d = new Accesos();

            string query = "DELETE from Jabones WHERE Id_Jabon=" + jabon.Id + "";

            return d.Escribir(query);
        }
    }
}
