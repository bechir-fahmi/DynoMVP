using Dyno.Platform.ReferentialData.DTO.BalanceData;
using Dyno.Platform.ReferentialData.DTO.RoleData;
using Platform.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.DTO.UserData
{
    public class UserProfileDTO
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string? Picture { get; set; }

        #region Token
        public string Token { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime ExpiredDate { get; set; }
        #endregion

        public IList<RoleDTO>? Roles { get; set; }
        public int Balance { get; set; }
    }
}
