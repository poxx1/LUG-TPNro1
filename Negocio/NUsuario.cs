using BE;
using DAL;
using System;

namespace BE
{
    public class NUsuario
    {
        public bool Insert(Usuarios usuario)
        {
            var d = new Accesos();
            //INSERT into Usuarios([User],Password) VALUES ('a','1');
            string query = "INSERT into Usuarios([User],Password) VALUES ('"+usuario.Us+"','"+usuario.Pw+"');";
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
            string query = "DELETE from Usuarios WHERE [User] ='"+usuario.Us+"';";
            return d.Write(query);
        }
    }
}
