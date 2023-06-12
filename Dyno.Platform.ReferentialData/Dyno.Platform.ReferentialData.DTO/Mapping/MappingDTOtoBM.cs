using AutoMapper;
using Dyno.Platform.ReferentialData.BusinessModel.TicketData;
using Dyno.Platform.ReferentialData.BusinessModel.UserClaimData;
using Dyno.Platform.ReferentialData.BusinessModel.UserData;
using Dyno.Platform.ReferentialData.BusinessModel.UserRole;
using Dyno.Platform.ReferentialData.DTO.RoleData;
using Dyno.Platform.ReferentialData.DTO.TicketData;
using Dyno.Platform.ReferentialData.DTO.UserClaimData;
using Dyno.Platform.ReferentialData.DTO.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.DTO.Mapping
{
    public class MappingDTOtoBM : Profile
    {
        public MappingDTOtoBM() 
        {
            CreateMap<UserDTO, User>().ReverseMap();
            CreateMap<EmployerDTO, Employer>().ReverseMap();
            CreateMap<EmployeeDTO, Employee>().ReverseMap();
            CreateMap<ShopOwnerDTO, ShopOwner>().ReverseMap();
            CreateMap<CasierDTO, Casier>().ReverseMap();
            CreateMap<SuperUserDTO, SuperUser>().ReverseMap();
            CreateMap<CategoryDTO, Category>().ReverseMap();
            CreateMap<TicketDTO, Ticket>().ReverseMap();
            CreateMap<PayementDTO, Payement>().ReverseMap();
            CreateMap<RoleDTO,Role>().ReverseMap();
            CreateMap<UserClaimDTO,UserClaim>().ReverseMap();
            CreateMap<RoleClaimDTO, RoleClaim>().ReverseMap();
        }
    }
}
