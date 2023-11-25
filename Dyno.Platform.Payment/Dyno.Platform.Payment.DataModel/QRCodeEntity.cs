using Platform.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.Payment.DataModel
{
    public class QRCodeEntity
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public DateTime ExpiredDate { get; set; }
        public QRStatus Status { get; set; }
    }
}
