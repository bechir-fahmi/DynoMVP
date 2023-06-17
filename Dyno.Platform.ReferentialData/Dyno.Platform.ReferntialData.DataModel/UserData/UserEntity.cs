

using Dyno.Platform.ReferntialData.DataModel.UserClaim;
using Dyno.Platform.ReferntialData.DataModel.UserRole;
using NHibernate.AspNetCore.Identity;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dyno.Platform.ReferntialData.DataModel.UserData
{
    

    public class UserEntity : IdentityUser
    {

        //public virtual ICollection<IdentityUserClaim> Claims { get; set; }
        [NotMapped]
        public override DateTimeOffset? LockoutEnd { get; set; }
        
        public virtual IList<RoleEntity> Roles { get; set; }
    }
}
