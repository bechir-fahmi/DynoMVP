using AutoMapper;
using Dyno.Platform.ReferentialData.BusinessModel.UserData;
using Dyno.Platform.ReferntialData.DataModel.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.BusinessModel.Mapping
{
    public class MappingBMtoDM : Profile
    {
        public MappingBMtoDM() {
            CreateMap<User, UserEntity>().ReverseMap();
            CreateMap<Employer, EmployerEntity>().ReverseMap();
            CreateMap<Employee, EmployeeEntity>().ReverseMap();
            CreateMap<ShopOwner, ShopOwnerEntity>().ReverseMap();   
            CreateMap<Casier, CasierEntity>().ReverseMap();
            CreateMap<SuperUser, SuperUserEntity>().ReverseMap();
        }
    }
}
