using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.Payment.DTO
{
    public class TransactionDTO
    {
        public Guid Id { get; set; } 
        public string SendUserId { get; set; } = string.Empty;
        public string ReceiveUserId { get; set; } = string.Empty;
        public QRCodeDTO QRCode { get; set; } = new QRCodeDTO();
    }
}
