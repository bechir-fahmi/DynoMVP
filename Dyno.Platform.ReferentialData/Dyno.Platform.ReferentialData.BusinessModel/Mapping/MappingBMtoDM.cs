using AutoMapper;
using Dyno.Platform.ReferentialData.BusinessModel.TicketData;
using Dyno.Platform.ReferentialData.BusinessModel.UserData;
using Dyno.Platform.ReferentialData.BusinessModel.UserRole;
using Dyno.Platform.ReferntialData.DataModel.PayementData;
using Dyno.Platform.ReferntialData.DataModel.UserData;
using Dyno.Platform.ReferntialData.DataModel.UserRole;
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
            CreateMap<Category, CategoryEntity>().ReverseMap();
            CreateMap<Ticket, TicketEntity>().ReverseMap();
            CreateMap<Payement, PayementEntity>().ReverseMap();
            CreateMap<Role,RoleEntity>().ReverseMap();
        }
    }
}
