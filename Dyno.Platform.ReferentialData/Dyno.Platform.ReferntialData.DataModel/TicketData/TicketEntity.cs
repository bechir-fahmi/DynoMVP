using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferntialData.DataModel.PayementData
{
    public class TicketEntity
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual double amount { get; set; }
    }
}
