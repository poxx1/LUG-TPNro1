using Negocio;
using DAL;
using Seguridad;
using System.Collections.Generic;
using System.Data;

namespace Mapper
{
    public class MUsers
    {
        public List<Negocio.Usuarios> LoadUsers()
        {
            var t = new DataTable();
            var a = new Accesos();
            var d = new Cripter();
            var ListUsers = new List<Negocio.Usuarios>();
            var query = "SELECT * FROM Usuarios";

            t = a.Read(query);

            if (t.Rows.Count > 0)
            {
                foreach (DataRow f in t.Rows)
                {
                    var us = new Negocio.Usuarios();
                    //Aca te llamo al desencriptador porque sino no voy a entender un carajo

                    us.Us = f[0].ToString();

                    us.Us = d.Desencriptar(us.Us);

                    ListUsers.Add(us);
                }
            }
            else
                ListUsers = null;

            return ListUsers;
        }

        public bool Insert(Usuarios usuario)
        {
            var d = new Accesos();
            //INSERT into Usuarios([User],Password) VALUES ('a','1');
            string query = "INSERT into Usuarios([User],Password) VALUES ('" + usuario.Us + "','" + usuario.Pw + "');";
            return d.Write(query);
        }

        public bool Update(Usuarios usuario)
        {
            var d = new Accesos();
            string query = "UPDATE Usuarios SET Password='" + usuario.Pw + "' WHERE [User]='" + usuario.Us + "'";
            return d.Write(query);
        }

        public bool Delete(Usuarios usuario)
        {
            var d = new Accesos();
            string query = "DELETE from Usuarios WHERE [User] ='" + usuario.Us + "';";
            return d.Write(query);
        }
    }
}
