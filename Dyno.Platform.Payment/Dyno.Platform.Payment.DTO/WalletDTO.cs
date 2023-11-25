using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.Payment.DTO
{
    public class WalletDTO 
    {
        public Guid Id { get; set; }
        public string PublicAddres { get; set; } = string.Empty;
        public string PrivateKey { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public int Balance { get; set; }

    }
}
