using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.BusinessModel.TicketData
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Ticket Ticket { get; set; }
    }
}
