using DAL;
using Mapper;
using System;
using System.Collections.Generic;
using System.Data;

namespace Negocio
{
    public class NLocalidad
    {
        public List<Negocio.Localidades> LoadLocalidades()
        {
            var mj = new MLocalidad();
            return mj.LoadLocalidades();
        }

        public bool Insert(Negocio.Localidades j)
        {
            var mj = new MLocalidad();
            return mj.Insert(j);
        }

        public bool Update(Negocio.Localidades j)
        {
            var mj = new MLocalidad();
            return mj.Update(j);
        }

        public bool Delete(Negocio.Localidades j)
        {
            var mj = new MLocalidad();
            return mj.Delete(j);
        }
    }
}
