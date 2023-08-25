using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.BusinessModel.UserData
{
    public class UserOtp
    {
        public int Id { get; set; }
        //public string? UserName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Code { get; set; }
    }
}
