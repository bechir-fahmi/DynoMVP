
using Dyno.Platform.ReferentialData.BusinessModel.AddressData;
using Dyno.Platform.ReferentialData.BusinessModel.BalanceData;
using Dyno.Platform.ReferentialData.BusinessModel.UserClaimData;
using Dyno.Platform.ReferentialData.BusinessModel.UserRole;
using NHibernate.AspNetCore.Identity;
using NHibernate.Engine;
using Platform.Shared.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.BusinessModel.UserData
{
    public class User : IdentityUser
    {
        #region User Data
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string? Picture { get; set; }
        #endregion

        #region Structure
        [JsonIgnore]
        public IList<Role>? Roles { get; set; }
        public IList<Address>? Addresses { get; set; }
        public IList<Balance>? Balances { get; set; }
        #endregion

    }
}
