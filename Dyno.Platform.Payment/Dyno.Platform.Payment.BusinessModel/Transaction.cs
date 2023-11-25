using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.Payment.BusinessModel
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public string SendUserId { get; set; } = string.Empty;
        public string ReceiveUserId { get; set; } = string.Empty;
        public QRCode QRCode { get; set; } = new QRCode();
    }
}
