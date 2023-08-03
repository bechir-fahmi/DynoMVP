using Dyno.Platform.ReferentialData.DTO.AddressData;
using Dyno.Platform.ReferentialData.DTO.RoleData;
using Dyno.Platform.ReferentialData.DTO.UserClaimData;
using NHibernate.AspNetCore.Identity;
using Platform.Shared.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.DTO.UserData
{
    public class UserDTO : IdentityUser
    {

        //public ICollection<IdentityUserClaim> Claims { get; set; }
        [NotMapped]
        public override DateTimeOffset? LockoutEnd { get; set; }

        public IList<RoleDTO> Roles { get; set; }
        public IList<AddressDTO> Address { get; set; }

    }
}