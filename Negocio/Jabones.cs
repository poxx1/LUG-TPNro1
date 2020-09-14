using System;
using System.Collections.Generic;
using System.Data;
using DAL;
using BE;

namespace Negocio
{
    public class Jabones
    {
        DataSet ds = new DataSet();
        Accesos datos = new Accesos();

        public List<Jabones> CargarJabones()
        {
            string query = "SELECT * FROM Bohemia.dbo.Jabones";
            ds = datos.ReadDS(query);
            var listaJabones = new List<Jabones>();

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in ds.Tables[0].Rows)
                {
                    var jabon = new BE.Jabones();
                    var bllJabones = new Negocio.Jabones();

                    jabon.Id = Convert.ToInt32(fila[0]);
                    jabon.Aroma = fila[1].ToString();
                    jabon.Base = fila[2].ToString();
                    jabon.Color = fila[3].ToString();
                    jabon.Cantidad = Convert.ToInt32(fila[4]);
                
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
