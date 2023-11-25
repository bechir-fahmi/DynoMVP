using Dyno.Platform.ReferentialData.BusinessModel.UserData;
using Dyno.Platform.ReferntialData.DataModel.UserData;
using Platform.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.BusinessModel.BalanceData
{
    public class Balance
    {
        public  int Id { get; set; }
        public  double Amount { get; set; }
        public string? Key { get; set; }
        public string? PublicAddress { get; set; }
        public  Status Status { get; set; }
        public User User { get; set; }
    }
}
