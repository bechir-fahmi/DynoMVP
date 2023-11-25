using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.Payment.DataModel
{
    public class TransactionEntity
    {
        public Guid Id { get; set; }
        public string SendUserId { get; set; } = string.Empty;
        public string ReceiveUserId { get; set; } = string.Empty;
        public QRCodeEntity QRCode { get; set; } = new QRCodeEntity();
    }
}
