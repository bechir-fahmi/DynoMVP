using AutoMapper;
using Dyno.Platform.ReferentialData.BusinessModel.AddressData;
using Dyno.Platform.ReferentialData.BusinessModel.UserClaimData;
using Dyno.Platform.ReferentialData.BusinessModel.UserData;
using Dyno.Platform.ReferentialData.BusinessModel.UserRole;
using Dyno.Platform.ReferntialData.DataModel;
using Dyno.Platform.ReferntialData.DataModel.AddressData;
using Dyno.Platform.ReferntialData.DataModel.UserClaim;
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
            CreateMap<Address, AddressEntity>().ReverseMap();
            CreateMap<UserOtp, UserOtpEntity>().ReverseMap();
            CreateMap<Role,RoleEntity>().ReverseMap();
            CreateMap<UserClaim, UserClaimEntity>().ReverseMap();
            CreateMap<RoleClaim, RoleClaimEntity>().ReverseMap();
            CreateMap<Test, TestData>().ReverseMap();
        }
    }
}
