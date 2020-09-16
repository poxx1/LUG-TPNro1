using DAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace Mapper
{
    public class MLocalidad
    {
        public List<Negocio.Localidades> LoadLocalidades()
        {
            var t = new DataTable();
            var a = new Accesos();
            var ListLocalidades = new List<Negocio.Localidades>();
            var query = "SELECT * FROM Localidad";

            t = a.Read(query);

            if (t.Rows.Count > 0)
            {
                foreach (DataRow f in t.Rows)
                {
                    var Localidad = new Negocio.Localidades();
                    Localidad.ID_Localidad = Convert.ToInt32(f[0]);
                    Localidad.Nombre_Localidad = "." + f[1].ToString();
                    ListLocalidades.Add(Localidad);
                }
            }
            else
                ListLocalidades = null;

            return ListLocalidades;
        }

        public bool Insert(Negocio.Localidades l)
        {
            var a = new Accesos();
            var query = "INSERT into Localidad (ID_Localidad,Nombre_Localidad) VALUES ('" + l.ID_Localidad + "','" + l.Nombre_Localidad + "');";
            return a.Write(query);
        }

        public bool Update(Negocio.Localidades l)
        {
            var a = new Accesos();
            var query = "UPDATE Localidad SET Nombre_Localidad = '" + l.Nombre_Localidad + "' WHERE ID_Localidad = " + l.ID_Localidad + "";
            return a.Write(query);
        }

        public bool Delete(Negocio.Localidades l)
        {
            var a = new Accesos();
            var query = "DELETE FROM Localidad WHERE ID_Localidad = " + l.ID_Localidad + "";
            return a.Write(query);
        }
    }
}
