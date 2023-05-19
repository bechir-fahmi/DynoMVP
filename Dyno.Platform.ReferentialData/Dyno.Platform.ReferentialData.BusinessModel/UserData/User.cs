
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
        [NotMapped]
        public override DateTimeOffset? LockoutEnd { get; set; }

    }
}
