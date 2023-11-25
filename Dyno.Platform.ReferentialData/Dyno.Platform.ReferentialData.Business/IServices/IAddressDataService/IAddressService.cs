using Dyno.Platform.ReferentialData.DTO.AddressData;
using Dyno.Platform.ReferentialData.DTO.UserData;
using Dyno.Platform.ReferntialData.DataModel.AddressData;
using Platform.Shared.GenericService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.Business.IServices.IAddressDataService
{
    public interface IAddressService : IGenericSyncService<AddressDTO, AddressEntity, Guid, AddressDTO>
    {
        List<AddressDTO> GetAddressByUserId(string userId);
        AddressDTO GetAddressByName(string adressName);
    }
}
