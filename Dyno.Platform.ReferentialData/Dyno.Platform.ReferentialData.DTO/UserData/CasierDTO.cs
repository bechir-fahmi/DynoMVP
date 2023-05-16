using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.DTO.UserData
{
    public class CasierDTO 
    {
        public Guid Id { get; set; }
        public UserDTO User { get; set; }
        public ShopOwnerDTO? ShopOwner { get; set; }
    }
}
