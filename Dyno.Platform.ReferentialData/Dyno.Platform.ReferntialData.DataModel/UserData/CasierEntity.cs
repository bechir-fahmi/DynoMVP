using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferntialData.DataModel.UserData
{
    public class CasierEntity 
    {
        public virtual Guid Id { get; set; }
        public virtual UserEntity User { get; set; }
        public virtual ShopOwnerEntity? ShopOwner { get; set; }
    }
}
