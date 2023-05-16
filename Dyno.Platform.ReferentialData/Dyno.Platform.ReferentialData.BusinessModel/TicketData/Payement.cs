using Dyno.Platform.ReferentialData.BusinessModel.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.BusinessModel.TicketData
{
    public class Payement
    {
        public int Id { get; set; }
        public DateTime date { get; set; }
        public int DayOfWork { get; set; }
        public Employee Employee { get; set; }
        public Employer Employer { get; set; }

    }
}
