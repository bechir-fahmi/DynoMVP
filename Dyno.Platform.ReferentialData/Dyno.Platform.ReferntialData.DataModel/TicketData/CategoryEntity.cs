using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferntialData.DataModel.PayementData
{
    public class CategoryEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual TicketEntity Ticket { get; set; }
    }
}
