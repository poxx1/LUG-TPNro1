using DAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace Negocio
{
    public class NLocalidad
    {
        public List<BE.Localidades> LoadLocalidades()
        {
            var t = new DataTable();
            var a = new Accesos();
            var ListLocalidades = new List<BE.Localidades>();
            var query = "SELECT * FROM Localidad";
            
            t = a.Read(query);

            if (t.Rows.Count > 0)
            {
                foreach (DataRow f in t.Rows)
                {
                    var Localidad = new BE.Localidades();
                    Localidad.ID_Localidad = Convert.ToInt32(f[0]);
                    Localidad.Nombre_Localidad = "."+f[1].ToString();
                    ListLocalidades.Add(Localidad);
                }
            }
            else
                ListLocalidades = null;

            return ListLocalidades;
        }

        public bool Insert(BE.Localidades l)
        {
            var a = new Accesos();
            var query = "INSERT into Localidad (ID_Localidad,Nombre_Localidad) VALUES ('"+l.ID_Localidad+"','"+l.Nombre_Localidad+"');";
            return a.Escribir(query);
        }

        public bool Update(BE.Localidades l)
        {
            var a = new Accesos();
            var query = "UPDATE Localidad SET Nombre_Localidad = '"+l.Nombre_Localidad+"' WHERE ID_Localidad = "+l.ID_Localidad+"";
            return a.Escribir(query);
        }

        public bool Delete(BE.Localidades l)
        {
            var a = new Accesos();
            var query = "DELETE FROM Localidad WHERE ID_Localidad = "+l.ID_Localidad+"";
            return a.Escribir(query);
        }
    }
}
