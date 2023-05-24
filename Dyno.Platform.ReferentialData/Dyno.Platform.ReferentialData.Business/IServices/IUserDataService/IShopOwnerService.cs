using Dyno.Platform.ReferentialData.DTO.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.Business.IServices.IUserDataService
{
    public interface IShopOwnerService : IGenericService<ShopOwnerDTO>
    {
        ShopOwnerDTO GetByEmail(string email);
        ShopOwnerDTO GetById(Guid id);
        void Delete(Guid id);
        ShopOwnerDTO GetByUserName(string name);
    }
}
