using AutoMapper;
using Dyno.Platform.ReferentialData.BusinessModel.AddressData;
using Dyno.Platform.ReferentialData.BusinessModel.UserClaimData;
using Dyno.Platform.ReferentialData.BusinessModel.UserData;
using Dyno.Platform.ReferentialData.BusinessModel.UserRole;
using Dyno.Platform.ReferentialData.DTO.AddressData;
using Dyno.Platform.ReferentialData.DTO.AuthDTO;
using Dyno.Platform.ReferentialData.DTO.RoleData;

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
            CreateMap<AddressDTO, Address>().ReverseMap();
            CreateMap<RoleDTO,Role>().ReverseMap();
            CreateMap<UserClaimDTO,UserClaim>().ReverseMap();
            CreateMap<RoleClaimDTO, RoleClaim>().ReverseMap();
            CreateMap<RegisterModelDTO, User>().ReverseMap();
            CreateMap<UpdateUserDTO, User>().ReverseMap();
        }
    }
}
