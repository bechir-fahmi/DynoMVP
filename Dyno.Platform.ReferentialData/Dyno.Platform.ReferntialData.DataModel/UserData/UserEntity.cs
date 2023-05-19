

using NHibernate.AspNetCore.Identity;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dyno.Platform.ReferntialData.DataModel.UserData
{
    

    public class UserEntity : IdentityUser
    {

        [NotMapped]
        public override DateTimeOffset? LockoutEnd { get; set; }
    }
}
