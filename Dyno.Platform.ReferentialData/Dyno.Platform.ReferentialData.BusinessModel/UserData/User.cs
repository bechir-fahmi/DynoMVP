
using Dyno.Platform.ReferentialData.BusinessModel.UserClaimData;
using Dyno.Platform.ReferentialData.BusinessModel.UserRole;
using NHibernate.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.BusinessModel.UserData
{
    public class User:IdentityUser

    {
        //public ICollection<IdentityUserClaim> Claims { get; set; }
        [NotMapped]
        public override DateTimeOffset? LockoutEnd { get; set; }

        public IList<Role> Roles { get; set; }
    }
}
