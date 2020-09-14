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
            Accesos d = new Accesos();
            string query = "Insert into Jabones (ID_Jabon, Color, Aroma, Base, Cantidad) values ('"+jabon.Id
                +"','"+jabon.Color+"','"+jabon.Aroma+"','"+jabon.Base+"',"+jabon.Cantidad+")";

            return d.Escribir(query);
        }
    }
}
