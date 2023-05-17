using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.BusinessModel.TicketData
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double amount { get; set; }
    }
}
