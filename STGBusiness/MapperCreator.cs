using STG.Business.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STGBusiness
{
    public static class MapperCreator
    {
        private static bool _created = false;

        public static void Create()
        {
            if (!_created)
            {
                AutoMapper.Mapper.CreateMap<Game, STG.DataAccess.DataModels.Game>();
            }
        }
    }
}
