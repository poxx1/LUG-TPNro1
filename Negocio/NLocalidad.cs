using DAL;
using Mapper;
using System;
using System.Collections.Generic;
using System.Data;

namespace Negocio
{
    public class NLocalidad
    {
        public List<BE.Localidades> LoadLocalidades()
        {
            var mj = new MLocalidad();
            return mj.LoadLocalidades();
        }

        public bool Insert(BE.Localidades j)
        {
            var mj = new MLocalidad();
            return mj.Insert(j);
        }

        public bool Update(BE.Localidades j)
        {
            var mj = new MLocalidad();
            return mj.Update(j);
        }

        public bool Delete(BE.Localidades j)
        {
            var mj = new MLocalidad();
            return mj.Delete(j);
        }
    }
}
