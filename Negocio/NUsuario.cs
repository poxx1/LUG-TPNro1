using Negocio;
using DAL;
using Mapper;
using Seguridad;
using System.Collections.Generic;
using System.Data;

namespace Negocio
{
    public class NUsuario
    {
        public List<Negocio.Usuarios> LoadUsers()
        {
            var mj = new MUsers();
            return mj.LoadUsers();
        }

        public bool Insert(Usuarios u)
        {
            var mj = new MUsers();
            return mj.Insert(u);
        }

        public bool Update(Usuarios u)
        {
            var mj = new MUsers();
            return mj.Update(u);
        }

        public bool Delete(Usuarios u)
        {
            var mj = new MUsers();
            return mj.Delete(u);
        }
    }
}

