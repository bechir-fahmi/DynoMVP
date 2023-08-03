using Dyno.Platform.ReferentialData.DTO.AddressData;
using Dyno.Platform.ReferentialData.DTO.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dyno.Platform.ReferentialData.Business.IServices.IAddressDataService
{
    public interface IAddressService
    {
        IList<AddressDTO> GetAllAddresses();
        IList<AddressDTO> GetAddressByUserId(string userId);
        AddressDTO GetAddressByName(string adressName);
        void CreateAddress(AddressDTO addressDTO);
        void UpdateAddress(AddressDTO addressDTO);
        void DeleteAddress(int id);

    }
}
