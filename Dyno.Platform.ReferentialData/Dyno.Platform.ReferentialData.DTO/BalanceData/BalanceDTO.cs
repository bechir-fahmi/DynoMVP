using Dyno.Platform.ReferentialData.BusinessModel.UserData;
using Dyno.Platform.ReferentialData.DTO.UserData;
using Platform.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.DTO.BalanceData
{
    public class BalanceDTO
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string Key { get; set; }
        public Status Status { get; set; }
        public UserDTO User { get; set; }
    }
}
