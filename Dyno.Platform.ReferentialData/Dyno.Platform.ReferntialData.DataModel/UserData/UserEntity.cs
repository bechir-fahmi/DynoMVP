using Dyno.Platform.ReferntialData.DataModel.AddressData;
using Dyno.Platform.ReferntialData.DataModel.BalanceData;
using Dyno.Platform.ReferntialData.DataModel.UserRole;
using NHibernate.AspNetCore.Identity;
using Platform.Shared.Enum;
using System.ComponentModel.DataAnnotations.Schema;


namespace Dyno.Platform.ReferntialData.DataModel.UserData
{
    

    public class UserEntity : IdentityUser
    {

        //public virtual ICollection<IdentityUserClaim> Claims { get; set; }
        [NotMapped]
        public override DateTimeOffset? LockoutEnd { get; set; }
        
        public virtual IList<RoleEntity> Roles { get; set; }
        public virtual IList<AddressEntity> Addresses { get; set; }
        public virtual IList<BalanceEntity> Balances { get; set; }



    }
}
