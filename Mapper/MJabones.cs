using System;
using System.Collections.Generic;
using System.Data;
using BE;
using DAL;
using Seguridad;

namespace Mapper
{
    public class MJabones
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
            string query = "INSERT into Jabones (ID_Jabon, Color, Aroma, Base, Cantidad) VALUES ('" + jabon.Id
                + "','" + jabon.Color + "','" + jabon.Aroma + "','" + jabon.Base + "'," + jabon.Cantidad + ")";

            return d.Write(query);
        }

        public bool Update(BE.Jabones jabon)
        {
            var d = new Accesos();

            string query = "UPDATE Jabones SET Color = '" + jabon.Color + "', Aroma ='" +
                jabon.Aroma + "', Base = '" + jabon.Base + "', Cantidad = " + jabon.Cantidad +
                "WHERE Id_Jabon =" + jabon.Id + "";

            return d.Write(query);
        }

        public bool Delete(BE.Jabones jabon)
        {
            var d = new Accesos();

            string query = "DELETE from Jabones WHERE Id_Jabon=" + jabon.Id + "";

            return d.Write(query);
        }

        #region Metodos de los informes

        public List<string> SelectAROMAS()
        {
            DataSet ds = new DataSet();
            Accesos datos = new Accesos();
            var counterAroma = 0;
            var stringAroma = "";

            string query = "SELECT Aroma, COUNT(Aroma) as 'Cantidad' FROM Jabones GROUP by Jabones.Aroma";

            ds = datos.ReadDS(query);

            var listaJabones = new List<string>();

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in ds.Tables[0].Rows)
                {
                    var jabon = new BE.Jabones();

                    //Aroma
                    stringAroma = fila[0].ToString();

                    counterAroma = Convert.ToInt32(fila[1]);

                    listaJabones.Add(stringAroma + ": " + counterAroma.ToString());
                }
            }
            else
            {
                listaJabones = null;
            }
            return listaJabones;
        }

        public List<string> SelectBASES()
        {
            DataSet ds = new DataSet();
            Accesos datos = new Accesos();
            var counterAroma = 0;
            var stringAroma = "";

            string query = "SELECT Base, COUNT(Base) as 'Cantidad' FROM Jabones GROUP by Jabones.Base";

            ds = datos.ReadDS(query);

            var listaJabones = new List<string>();

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in ds.Tables[0].Rows)
                {
                    var jabon = new BE.Jabones();

                    //Aroma
                    stringAroma = fila[0].ToString();

                    counterAroma = Convert.ToInt32(fila[1]);

                    listaJabones.Add(stringAroma + ": " + counterAroma.ToString());
                }
            }
            else
            {
                listaJabones = null;
            }
            return listaJabones;
        }

        public List<string> SelectCOLORES()
        {
            DataSet ds = new DataSet();
            Accesos datos = new Accesos();
            var counterAroma = 0;
            var stringAroma = "";

            string query = "SELECT Color, COUNT(Color) as 'Cantidad' FROM Jabones GROUP by Jabones.Color";

            ds = datos.ReadDS(query);

            var listaJabones = new List<string>();

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in ds.Tables[0].Rows)
                {
                    var jabon = new BE.Jabones();

                    //Aroma
                    stringAroma = fila[0].ToString();

                    counterAroma = Convert.ToInt32(fila[1]);

                    listaJabones.Add(stringAroma + ": " + counterAroma.ToString());
                }
            }
            else
            {
                listaJabones = null;
            }
            return listaJabones;
        }

        #endregion
    }
}
